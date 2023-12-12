using UniRx;

namespace ViewModels
{
    public interface ICharacterStatViewModel: IViewModel
    {
        public IReadOnlyReactiveProperty<int> Value { get; }
        public string Name { get; }
    }
}