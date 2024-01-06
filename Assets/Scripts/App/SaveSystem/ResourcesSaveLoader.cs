using System.Linq;
using GameEngine;
using Zenject;

namespace App.SaveSystem
{
    public class ResourcesSaveLoader: SaveLoader<ResourceSnapshot[], ResourceService>
    {
        [Inject]
        public ResourcesSaveLoader(GameFacade gameFacade) : base(gameFacade)
        {
        }
        
        protected override ResourceSnapshot[] ConvertToData(ResourceService service)
        {
            var resources = service.GetResources();

            return resources.Select(resource => resource.GetSnapshot()).ToArray();
        }

        protected override void SetupData(ResourceService service, ResourceSnapshot[] data)
        {
            service.SetupResource(data);
        }

        
    }
}