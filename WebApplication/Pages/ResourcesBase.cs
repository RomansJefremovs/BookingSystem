using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace WebApplication.Pages
{  
    public class ResourcesBase: ComponentBase
    {
        public IEnumerable<Resource> Resources  { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadResources);
        }

        private void LoadResources()
        {
           
            Resource r1 = new Resource
            {
                Id = 1,
                Name = "gg",
                Quantity = 2
            };
            Resource r2 = new Resource
            {
                Id = 2,
                Name = "gg",
                Quantity = 1
            };
            Resource r3 = new Resource
            {
                Id = 3,
                Name = "gg",
                Quantity = 2
            };
            Resources = new List<Resource> {r1,r2,r3 };
        }
    }
}