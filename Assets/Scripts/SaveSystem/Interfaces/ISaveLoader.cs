using Zenject;

namespace SaveSystem
{
    public interface ISaveLoader
    {
        void SaveData(GameRepository gameRepository, DiContainer container);
        void LoadData(GameRepository gameRepository, DiContainer container);
    }
}