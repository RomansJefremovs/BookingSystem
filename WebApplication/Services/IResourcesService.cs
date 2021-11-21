using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApplication.Services
{
    public interface IResourcesService
    {
        Task<IEnumerable<Resource>> GetResources();
        Task<ActionResult<Resource>> GetResource(int id);
        Task<ActionResult<Resource>> CreateResource(Resource resource);
        Task<ActionResult<Resource>> UpdateResource(Resource resource);
        Task DeleteResource(int id);
    }
}