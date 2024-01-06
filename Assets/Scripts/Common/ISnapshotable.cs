namespace Common
{
    public interface ISnapshotable<T>
    {
        void SetSnapshot(T snapshot);
        T GetSnapshot();
    }
}