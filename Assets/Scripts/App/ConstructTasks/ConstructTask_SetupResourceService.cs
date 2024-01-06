using GameEngine;
using UnityEngine;
using Zenject;
using Resource = GameEngine.Resource;

namespace App.ConstructTasks
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