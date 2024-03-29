﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class ResourceController: ControllerBase
    {
        private readonly IResourceRepository resourceRepository;
        public ResourceController(IResourceRepository resourceRepository)
        {
            this.resourceRepository = resourceRepository;

        }
        
        [HttpGet]
        public async Task<ActionResult> GetResources()
        {
            try
            {
                return Ok(await resourceRepository.GetResources());
            }
            catch (Exception e)
            {
                StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving from the database ");
                throw;
            }
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Resource>> GetResource(int id)
        {
            try
            {
                var result = await resourceRepository.GetResource(id);
                if (result == null )
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving from the database ");
                
            }
        }
        [HttpPost]
        public async Task<ActionResult<Resource>> CreateResource(Resource resource)
        {
            try
            {
                if (resource == null)
                {
                    return BadRequest();
                }
                var createdResource = await resourceRepository.AddResource(resource);

                return CreatedAtAction(nameof(GetResource),new {id = createdResource.Id},createdResource );
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving from the database ");
                
            }
            
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Resource>> UpdateResource(int id, Resource resource)
        {
            try
            {
                if (id != resource.Id)
                {
                    return BadRequest("Resource ID mismatch");
                }
                var res = await resourceRepository.GetResource(id);
                if (res == null)
                {
                    return NotFound($"Resource with ID = {id} not found");
                }

                return await resourceRepository.UpdateResource(resource);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Resource>> DeleteResource(int id)
        {
            try
            {
                var res = await resourceRepository.GetResource(id);
                if (res == null)
                {
                    return NotFound($"Resource with ID = {id} not found");
                }

               return await resourceRepository.DeleteResource(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error deleting  data");
            }
        }
    }
}