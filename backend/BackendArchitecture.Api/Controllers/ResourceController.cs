using BackendArchitecture.Api.Models;
using BackendArchitecture.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendArchitecture.Api.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [ApiController]
    [Route("resources")]
    public class ResourceController : ControllerBase
    {
        private readonly ILogger<ResourceWithRepoController> _logger;
        private readonly MyDatabaseDbContext _dbContext;

        public ResourceController(
            ILogger<ResourceWithRepoController> logger,
            MyDatabaseDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Resource>> GetAll()
        {
            try
            {
                return _dbContext.Resources.ToList();
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "Resource")]
        public ActionResult<Resource> Get(Guid id)
        {
            try
            {
                var resource = _dbContext.Resources.Where(res => res.Id == id).FirstOrDefault();

                if (resource == null)
                {
                    return NotFound();
                }

                return resource;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult<IEnumerable<Resource>> Post([FromBody] Resource resource)
        {
            try
            {
                resource.Id = Guid.Empty;

                var result = _dbContext.Resources.Add(resource);
                _dbContext.SaveChanges();

                return CreatedAtRoute("Resource", new { id = result.Entity.Id }, result.Entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Resource>> Put(Guid id, [FromBody] Resource resource)
        {
            try
            {
                resource.Id = id;

                _dbContext.Entry(resource).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();

                return AcceptedAtRoute("Resource", new { id }, resource);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }

        [HttpDelete("id")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _dbContext.Resources.Remove(new Resource { Id = id });
                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }
    }
}
