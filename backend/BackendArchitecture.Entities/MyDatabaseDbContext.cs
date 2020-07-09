using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendArchitecture.Entities
{
    public class MyDatabaseDbContext : IdentityDbContext<User>
    {
        public MyDatabaseDbContext(DbContextOptions options)
            : base(options)
        {
        
        }

        public DbSet<Link> Links { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<AnalysisTagResult> AnalysisTagResult { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Users
            var userAdmin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };

            userAdmin.PasswordHash = new PasswordHasher<User>().HashPassword(userAdmin, "Admin123!");

            var userMesud = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Mesud",
                NormalizedUserName = "MESUD"
            };

            userMesud.PasswordHash = new PasswordHasher<User>().HashPassword(userMesud, "Mesud123!");

            builder.Entity<User>().HasData(new User[] {
                 userAdmin,
                 userMesud
            });

            // Roles
            var roleAdmin = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin"
            };

            var roleUser = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User"
            };

            builder.Entity<IdentityRole>().HasData(new IdentityRole[]
            {
                roleAdmin,
                roleUser
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[] { 
                new IdentityUserRole<string>()
                {
                    UserId = userAdmin.Id,
                    RoleId = roleAdmin.Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = userAdmin.Id,
                    RoleId = roleUser.Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = userMesud.Id,
                    RoleId = roleUser.Id
                },
            });
        }
    }
}
