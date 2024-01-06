using GameEngine;
using UnityEngine;

namespace Zenject
{
    public class GameSceneInstaller: MonoInstaller
    {
        [SerializeField] private Transform unitContainer;
        [SerializeField] private UnitCatalog unitCatalog;
        public override void InstallBindings()
        {
            Container.Bind<UnitManager>().AsSingle().WithArguments(unitContainer);
            Container.Bind<ResourceService>().AsSingle();
            Container.BindInstances(unitCatalog);
            Container.Bind<UnitFactory>().AsSingle();
        }
    }
}