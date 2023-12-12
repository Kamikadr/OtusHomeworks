using System;
using Lessons.Architecture.PM;
using UniRx;

namespace ViewModels
{
    public class CharacterProgressBarViewModel: IDisposable
    {
        public IReadOnlyReactiveProperty<int> CurrentXp => _currentXp;
        public IReadOnlyReactiveProperty<int> RequiredXp => _requiredXp;
        private readonly ReactiveProperty<int> _currentXp;
        private readonly ReactiveProperty<int> _requiredXp;
        private readonly PlayerLevel _playerLevel;

        public CharacterProgressBarViewModel(PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;
            _currentXp = new ReactiveProperty<int>(_playerLevel.CurrentExperience);
            _requiredXp = new ReactiveProperty<int>(_playerLevel.RequiredExperience);
            _playerLevel.OnExperienceChanged += OnExperienceChanged;
            _playerLevel.OnLevelUp += OnLevelUp;
        }

        private void OnLevelUp()
        {
            _currentXp.Value = _playerLevel.CurrentExperience; //change to refresh
            _requiredXp.Value = _playerLevel.RequiredExperience;
        }

        private void OnExperienceChanged(int value)
        {
            _currentXp.Value = value;
        }

        public void Dispose()
        {
            _playerLevel.OnExperienceChanged -= OnExperienceChanged;
            _playerLevel.OnLevelUp -= OnLevelUp;
        }
    }

    public interface IProgressBarViewModel
    {
        public IReadOnlyReactiveProperty<int> CurrentXp { get; }
        public IReadOnlyReactiveProperty<int> RequiredXp { get; }
    }
}