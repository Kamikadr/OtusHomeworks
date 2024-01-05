using Zenject;

namespace SaveSystem
{
    public interface ISaveLoader
    {
        void SaveData(GameRepository gameRepository);
        void LoadData(GameRepository gameRepository);
    }
}