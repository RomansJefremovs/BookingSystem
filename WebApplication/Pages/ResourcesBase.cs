using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;
using WebApplication.Services;

namespace WebApplication.Pages
{  
    public class ResourcesBase: ComponentBase
    {
        [Inject]
        public IResourcesService ResourcesService { get; set; }
        public List<Resource> Resources { get; set; }
        public bool NewResourcePageOpen { get; set; }
        public bool BookDialogOpen { get; set; }
        protected Resource _resourceToBook;
        protected override async Task OnInitializedAsync()
        {
            Resources = (await ResourcesService.GetResources()).ToList(); 
        } 
        protected async Task RemoveResource(int Id)
        {
            Resource toRemove = Resources.First(r => r.Id == Id);
            await ResourcesService.DeleteResource(Id);
            Resources.Remove(toRemove);
        }
        protected void OnBookDialogClose(bool accepted)
        {
            if (accepted)
            {
                _resourceToBook = null;
            }
            BookDialogOpen = false;
            StateHasChanged();
        }

        protected void OpenBookDialog(Resource resource)
        {
            _resourceToBook = resource;
            BookDialogOpen = true;
            StateHasChanged();
        }
        
        protected void OpenNewResourcePage()
        {
            NewResourcePageOpen = true;
            StateHasChanged();
        }

    }
}