using SaveSystem;
using Tasks.LoadingTasks;
using Zenject;

namespace DefaultNamespace.Zenject
{
    public class AppInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFacade>().AsSingle();
            Container.Bind<IGameRepository>().To<GameRepository>().AsSingle();
            Container.Bind<GameLauncher>().AsSingle();
            Container.Bind<ISaveLoader>().To<ResourcesSaveLoader>().AsSingle();
            Container.Bind<ISaveLoader>().To<UnitSaveLoader>().AsSingle();
            Container.Bind<GameSaver>().AsSingle();

        }
    }
}