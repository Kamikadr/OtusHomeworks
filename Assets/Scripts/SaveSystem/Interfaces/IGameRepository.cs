namespace SaveSystem
{
    public interface IGameRepository
    {
        bool TryGetData<T>(out T value);
        void SetData<T>(T value);
        void LoadState();
        void SaveState();
    }
}