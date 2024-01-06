using Cysharp.Threading.Tasks;

namespace App
{
    public interface IGameRepository
    {
        bool TryGetData<T>(out T value);
        void SetData<T>(T value);
        UniTask LoadStateAsync();
        UniTask SaveStateAsync();
    }
}