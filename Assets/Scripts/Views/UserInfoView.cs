using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using ViewModels;

namespace Views
{
    public class UserInfoView: MonoBehaviour
    {
        [SerializeField] private Image characterIcon;
        [SerializeField] private TMP_Text level;
        [SerializeField] private TMP_Text description;
        [SerializeField] private TMP_Text characterName;

        private IUserInfoViewModel _viewModel;
        private CompositeDisposable _disposable;
        
        public void Initialize(object obj)
        {
            if (obj is not IUserInfoViewModel characterInfoViewModel)
            {
                throw new Exception("Expected UserInfoViewModel");
            }

            _viewModel = characterInfoViewModel;

            BindToViewModel();
        }

        private void BindToViewModel()
        {
            _disposable = new CompositeDisposable();
            _viewModel.Description.Subscribe(OnDescriptionChange).AddTo(_disposable);
            _viewModel.Name.Subscribe(OnNameChange).AddTo(_disposable);
            _viewModel.Icon.Subscribe(OnIconChange).AddTo(_disposable);
            _viewModel.Level.Subscribe(OnLevelChange).AddTo(_disposable);
        }
        private void OnDescriptionChange(string newValue)
        {
            description.text = _viewModel.Description.Value;
        }
        private void OnNameChange(string newValue)
        {
            characterName.text = $"@{_viewModel.Name.Value}";
        }
        private void OnIconChange(Sprite newValue)
        {
            characterIcon.sprite = _viewModel.Icon.Value;
        }
        private void OnLevelChange(int newValue)
        {
            level.text = $"Level: {_viewModel.Level.Value}";
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
            _disposable = null;
        }
    }

 
}