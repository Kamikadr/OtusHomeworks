using UniRx;

namespace ViewModels
{
    public interface IPopupViewModel: IViewModel
    {
        CharacterInfoViewModel CharacterInfoViewModel { get; }
        UserInfoViewModel UserInfoViewModel { get; }
        public CharacterProgressBarViewModel CharacterProgressBarViewModel { get; }
        IReadOnlyReactiveProperty<bool> CanLevelUp { get; }
        ReactiveCommand LevelUpCommand { get; }
    }
}