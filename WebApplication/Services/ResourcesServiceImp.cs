using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApplication.Services
{
    public class ResourcesServiceImp: IResourcesService

    {
        private readonly HttpClient httpClient;
        
        public ResourcesServiceImp(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Resource>> GetResources()
        {
            return await httpClient.GetJsonAsync<Resource[]>("apiResource");
        }

        public async Task<ActionResult<Resource>> GetResource(int id)
        {
            return await httpClient.GetFromJsonAsync<Resource>("apiResource/{id}");
        }

        public async Task<ActionResult<Resource>> CreateResource(Resource resource)
        {
            return await httpClient.PostJsonAsync<Resource>("apiResource", resource);
        }

        public async Task<ActionResult<Resource>> UpdateResource(Resource resource)
        {
            return await httpClient.PutJsonAsync<Resource>("apiResource", resource);
        }

        public async Task DeleteResource(int id)
        {
            await httpClient.DeleteAsync($"apiResource/{id}");
        }
    }
}