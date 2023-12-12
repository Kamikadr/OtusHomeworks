using Lessons.Architecture.PM;
using UniRx;

namespace ViewModels
{
    public class PopupViewModel: IPopupViewModel
    {
        public CharacterInfoViewModel CharacterInfoViewModel { get; }
        public UserInfoViewModel UserInfoViewModel { get; }
        public CharacterProgressBarViewModel CharacterProgressBarViewModel { get; }

        private readonly PlayerLevel _playerLevel;
        private CompositeDisposable _commandSubscribers;

        public IReadOnlyReactiveProperty<bool> CanLevelUp => _canLevelUp;
        public ReactiveCommand LevelUpCommand { get; }
        private ReactiveProperty<bool> _canLevelUp;

        public PopupViewModel(PlayerLevel playerLevel, CharacterInfo characterInfo, UserInfo userInfo)
        {
            CharacterInfoViewModel = new CharacterInfoViewModel(characterInfo);
            UserInfoViewModel = new UserInfoViewModel(playerLevel, userInfo);
            CharacterProgressBarViewModel = new CharacterProgressBarViewModel(playerLevel);
            
            _playerLevel = playerLevel;
            _playerLevel.OnExperienceChanged += OnExperienceChanged;
            
            LevelUpCommand = new ReactiveCommand(CanLevelUp);
            LevelUpCommand.Subscribe(LevelUp).AddTo(_commandSubscribers);
        }

        private void OnExperienceChanged(int _)
        {
            _canLevelUp.Value = _playerLevel.CanLevelUp();
        }

        private void LevelUp(Unit _)
        {
            _playerLevel.LevelUp();
        }
    }

    public interface IPopupViewModel
    {
        CharacterInfoViewModel CharacterInfoViewModel { get; }
        UserInfoViewModel UserInfoViewModel { get; }
        public CharacterProgressBarViewModel CharacterProgressBarViewModel { get; }
        IReadOnlyReactiveProperty<bool> CanLevelUp { get; }
        ReactiveCommand LevelUpCommand { get; }
    }
}