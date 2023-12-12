using System;
using Lessons.Architecture.PM;
using UniRx;
using UnityEngine;

namespace ViewModels
{
    public class UserInfoViewModel:IUserInfoViewModel, IDisposable
    {
        public IReadOnlyReactiveProperty<string> Name => _name;
        public IReadOnlyReactiveProperty<Sprite> Icon => _icon;
        public IReadOnlyReactiveProperty<string> Description => _description;
        public IReadOnlyReactiveProperty<int> Level => _level;
        
        private readonly PlayerLevel _playerLevel;
        private readonly UserInfo _userInfo;
        private ReactiveProperty<string> _name;
        private ReactiveProperty<Sprite> _icon;
        private ReactiveProperty<string> _description;
        private ReactiveProperty<int> _level;

        public UserInfoViewModel(PlayerLevel playerLevel, UserInfo userInfo)
        {
            _playerLevel = playerLevel;
            _userInfo = userInfo;
            _userInfo.OnDescriptionChanged += OnDescriptionChanged;
            _userInfo.OnIconChanged += OnIconChanged;
            _userInfo.OnNameChanged += OnNameChanged;
            _playerLevel.OnLevelUp += OnLevelChanged;
        }

        private void OnLevelChanged()
        {
            _level.Value = _playerLevel.CurrentLevel;
        }
        private void OnNameChanged(string newName)
        {
            _name.Value = newName;
        }

        private void OnIconChanged(Sprite newIcon)
        {
            _icon.Value = newIcon;
        }

        private void OnDescriptionChanged(string newDescription)
        {
            _description.Value = newDescription;
        }

        
        public void Dispose()
        {
            _userInfo.OnDescriptionChanged -= OnDescriptionChanged;
            _userInfo.OnIconChanged -= OnIconChanged;
            _userInfo.OnNameChanged -= OnNameChanged;
            _playerLevel.OnLevelUp -= OnLevelChanged;
        }
    }
}