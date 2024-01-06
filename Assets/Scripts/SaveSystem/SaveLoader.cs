using DefaultNamespace;
using Zenject;

namespace SaveSystem
{
    public abstract class SaveLoader<TData, TService>: ISaveLoader
    {
        private readonly GameFacade _gameFacade;

        protected SaveLoader(GameFacade gameFacade)
        {
            _gameFacade = gameFacade;
        }

        public void SaveData(IGameRepository gameRepository)
        {
            var resourceService = _gameFacade.GetService<TService>();
            var data = ConvertToData(resourceService);
            gameRepository.SetData(data);
        }

        public void LoadData(IGameRepository gameRepository)
        {
            var resourceService = _gameFacade.GetService<TService>();
            if (gameRepository.TryGetData<TData>(out var snapshots))
            {
                SetupData(resourceService, snapshots);
            }
        }

        protected abstract TData ConvertToData(TService service);
        protected abstract void SetupData(TService service, TData data);
    }
}