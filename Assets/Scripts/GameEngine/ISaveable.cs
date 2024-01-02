namespace GameEngine
{
    public interface ISaveable<T>
    {
        void SetSnapshot(T snapshot);
        T GetSnapshot();
    }
}