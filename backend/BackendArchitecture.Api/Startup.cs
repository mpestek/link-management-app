using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendArchitecture.Api.Helpers;
using BackendArchitecture.Api.Validators;
using BackendArchitecture.Api.Validators.Interfaces;
using BackendArchitecture.Business;
using BackendArchitecture.Common;
using BackendArchitecture.Entities;
using BackendArchitecture.Repositories;
using BackendArchitecture.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BackendArchitecture.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen();

            services.Configure<DatabaseConfiguration>(
                Configuration.GetSection(nameof(DatabaseConfiguration)));
            services.AddSingleton(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<DatabaseConfiguration>>().Value);

            services.AddDbContext<MyDatabaseDbContext>(
                options => options.UseSqlServer(
                    Configuration["DatabaseConfiguration:ConnectionString"], 
                    builder => builder.MigrationsAssembly("BackendArchitecture.Api")));

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<MyDatabaseDbContext>()
                    .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;

                    return Task.CompletedTask;
                };
            });

            services.AddScoped<IUserUtilities, UserUtilities>();

            services.AddScoped<ILinkValidator, LinkValidator>();
            services.AddScoped<IUriValidator, UriValidator>();

            services.AddScoped<IUriHandler, UriHandler>();

            services.AddScoped<ILinkRepository, LinkRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyDatabaseDbContext dbContext)
        {
            // Run any pending migrations
            dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                config.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors(policyBuider => policyBuider
                .WithOrigins(Configuration["ClientUrl"])
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
