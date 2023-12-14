using System;
using Lessons.Architecture.PM;
using UniRx;

namespace ViewModels
{
    public class PopupViewModel: IPopupViewModel, IDisposable
    {
        public event Action OnPopupHide;
        public CharacterInfoViewModel CharacterInfoViewModel { get; }
        public UserInfoViewModel UserInfoViewModel { get; }
        public CharacterProgressBarViewModel CharacterProgressBarViewModel { get; }
        public IReadOnlyReactiveProperty<bool> CanLevelUp => _canLevelUp;
        public ReactiveCommand LevelUpCommand { get; private set; }
        public ReactiveCommand HideCommand { get; private set; }

        private readonly PlayerLevel _playerLevel;
        private CompositeDisposable _commandSubscribers;
        private ReactiveProperty<bool> _canLevelUp;

        public PopupViewModel(PlayerLevel playerLevel, CharacterInfo characterInfo, UserInfo userInfo)
        {
            CharacterInfoViewModel = new CharacterInfoViewModel(characterInfo);
            UserInfoViewModel = new UserInfoViewModel(playerLevel, userInfo);
            CharacterProgressBarViewModel = new CharacterProgressBarViewModel(playerLevel);
            
            _playerLevel = playerLevel;
            _playerLevel.OnExperienceChanged += OnExperienceChanged;
            _playerLevel.OnLevelUp += LevelChanged;
            SetupReactiveParameter();
        }
        private void SetupReactiveParameter()
        {
            _canLevelUp = new ReactiveProperty<bool>(false);
            LevelUpCommand = new ReactiveCommand(CanLevelUp);
            HideCommand = new ReactiveCommand();
            _commandSubscribers = new CompositeDisposable();
            LevelUpCommand.Subscribe(LevelUp).AddTo(_commandSubscribers);
            HideCommand.Subscribe(Hide).AddTo(_commandSubscribers);
        }

        private void LevelChanged()
        {
            _canLevelUp.Value = _playerLevel.CanLevelUp();
        }
        
        private void OnExperienceChanged(int _)
        {
            _canLevelUp.Value = _playerLevel.CanLevelUp();
        }
        private void LevelUp(Unit _)
        {
            _playerLevel.LevelUp();
        }
        private void Hide(Unit _)
        {
            OnPopupHide?.Invoke();
        }
        public void Dispose()
        {
            _playerLevel.OnExperienceChanged -= OnExperienceChanged;
            _playerLevel.OnLevelUp -= LevelChanged;
            
            _commandSubscribers?.Dispose();
            _canLevelUp?.Dispose();
            UserInfoViewModel?.Dispose();
            CharacterProgressBarViewModel?.Dispose();
        }
    }
}