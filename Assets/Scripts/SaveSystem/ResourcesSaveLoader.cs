using System.Linq;
using GameEngine;

namespace SaveSystem
{
    public class ResourcesSaveLoader: SaveLoader<ResourceSnapshot[], ResourceService>
    {
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