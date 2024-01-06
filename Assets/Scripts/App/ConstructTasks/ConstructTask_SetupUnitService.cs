using GameEngine;
using UnityEngine;
using Zenject;

namespace App.ConstructTasks
{
    [CreateAssetMenu(
        fileName = "Task «Setup Unit Service»",
        menuName = "Game/Construct/Task «Setup Unit Service»"
    )]
    public sealed class ConstructTask_SetupUnitService : ConstructTask
    {
        public override void Construct(DiContainer container)
        {
            var unitManager = container.Resolve<UnitManager>();
            unitManager.SetupUnits(FindObjectsOfType<Unit>());
        }
    }
}