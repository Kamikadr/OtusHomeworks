using UniRx;

namespace ViewModels
{
    public interface IProgressBarViewModel: IViewModel
    {
        public IReadOnlyReactiveProperty<int> CurrentXp { get; }
        public IReadOnlyReactiveProperty<int> RequiredXp { get; }
    }
}