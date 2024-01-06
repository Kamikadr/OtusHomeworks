using App;
using App.LoadingTasks;
using App.SaveSystem;
using App.SaveSystem.Interfaces;
using Common;

namespace Zenject
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
            Container.Bind<FileEncryptor>().AsSingle();

        }
    }
}