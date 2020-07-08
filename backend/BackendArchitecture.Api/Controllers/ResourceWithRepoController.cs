using BackendArchitecture.Entities;
using BackendArchitecture.Repositories;
using BackendArchitecture.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendArchitecture.Api.Controllers
{
    [ApiController]
    [Route("resources-with-repo")]
    public class ResourceWithRepoController : ControllerBase
    {
        private readonly ILogger<ResourceWithRepoController> _logger;
        private readonly IResourceRepository _resourceRepository;

        public ResourceWithRepoController(
            ILogger<ResourceWithRepoController> logger,
            IResourceRepository resourceRepository)
        {
            _logger = logger;
            _resourceRepository = resourceRepository;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Resource>> GetAll()
        {
            try
            {
                return _resourceRepository.Get();
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "ResourceWithRepo")]
        public ActionResult<Resource> Get(Guid id)
        {
            try
            {
                var resource = _resourceRepository.Get(id);

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
                var createdResource = _resourceRepository.Create(resource);

                return CreatedAtRoute("ResourceWithRepo", new { id = createdResource.Id }, createdResource);
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

                _resourceRepository.Update(resource);

                return AcceptedAtRoute("ResourceWithRepo", new { id }, resource);
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
                _resourceRepository.Delete(id);

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
