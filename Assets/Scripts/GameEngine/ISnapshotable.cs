namespace GameEngine
{
    public interface ISnapshotable<T>
    {
        void SetSnapshot(T snapshot);
        T GetSnapshot();
    }
}