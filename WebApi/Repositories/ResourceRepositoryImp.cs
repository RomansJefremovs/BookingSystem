using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class ResourceRepositoryImp: IResourceRepository
    {
        private readonly MyDBContext myDbContext;

        public ResourceRepositoryImp(MyDBContext myDbContext)
        {
            this.myDbContext = myDbContext;  
        }
        
        public async Task<IEnumerable<Resource>> GetResources()
        {
            return await myDbContext.Resources.ToListAsync();
        }

        public async Task<Resource> GetResource(int resourceId)
        {
            return await myDbContext.Resources.FirstOrDefaultAsync(r => r.Id == resourceId);
        }

        public async Task<Resource> AddResource(Resource resource)
        {
           var result = await myDbContext.Resources.AddAsync(resource);
           await myDbContext.SaveChangesAsync();
           return result.Entity;
        }

        public async Task<Resource> UpdateResource(Resource resource)
        {
            var result = await myDbContext.Resources.FirstOrDefaultAsync(r=>r.Id == resource.Id);
            if (result != null)
            {
                result.Id = resource.Id;
                result.Name = resource.Name;
                result.Quantity = resource.Quantity;
                await myDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async   Task<Resource> DeleteResource(int resourceId)
        {
            var result = await myDbContext.Resources.FirstOrDefaultAsync(r => r.Id == resourceId );
            if (result != null)
            {
                myDbContext.Resources.Remove(result);
                await myDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}