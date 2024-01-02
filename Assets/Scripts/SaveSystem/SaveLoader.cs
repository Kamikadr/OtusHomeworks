using Zenject;

namespace SaveSystem
{
    public abstract class SaveLoader<TData, TService>: ISaveLoader
    {
        
        public void SaveData(GameRepository gameRepository, DiContainer container)
        {
            var resourceService = container.Resolve<TService>();
            var data = ConvertToData(resourceService);
            gameRepository.SetData(data);
        }

        public void LoadData(GameRepository gameRepository, DiContainer container)
        {
            var resourceService = container.Resolve<TService>();
            if (gameRepository.TryGetData<TData>(out var snapshots))
            {
                SetupData(resourceService, snapshots);
            }
        }

        protected abstract TData ConvertToData(TService service);
        protected abstract void SetupData(TService service, TData data);
    }
}