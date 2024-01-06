namespace App.SaveSystem.Interfaces
{
    public interface ISaveLoader
    {
        void SaveData(IGameRepository gameRepository);
        void LoadData(IGameRepository gameRepository);
    }
}