using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebApi.Repositories
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>> GetResources();
        Task<Resource> GetResource(int resourceId);
        Task<Resource> AddResource(Resource resource);
        Task<Resource> UpdateResource(Resource resource);
        void DeleteResource(int resourceId);
    }
}