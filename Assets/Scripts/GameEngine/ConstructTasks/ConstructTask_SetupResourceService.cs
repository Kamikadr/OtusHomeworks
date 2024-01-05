using UnityEngine;
using Zenject;

namespace GameEngine
{
    [CreateAssetMenu(
        fileName = "Task «Setup Resource Service»",
        menuName = "Game/Construct/Task «Setup Resource Service»"
    )]
    public sealed class ConstructTask_SetupResourceService : ConstructTask
    {
        public override void Construct(DiContainer container)
        {
            var resourceService = container.Resolve<ResourceService>();
            resourceService.SetResources(FindObjectsOfType<Resource>());
        }
    }
}