using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;
using WebApplication.Services;

namespace WebApplication.Pages
{
    public class NewResourceBase: ComponentBase
    {
        [Inject] public IResourcesService ResourceService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        public IEnumerable<Resource> Resources { get; set; }
        public Resource newResource = new Resource();

        protected override async Task OnInitializedAsync()
        {
            Resources = (await ResourceService.GetResources()).ToList();
        }
        protected void AddNewResource()
        {
            int max = Resources.Max(r => r.Id);
            newResource.Id = (++max);
            ResourceService.CreateResource(newResource);
            NavigationManager.NavigateTo("/");
        }
    }
}