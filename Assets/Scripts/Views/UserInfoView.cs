using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using ViewModels;

namespace Views
{
    public class UserInfoView: BaseView<IUserInfoViewModel>
    {
        [SerializeField] private Image characterIcon;
        [SerializeField] private TMP_Text level;
        [SerializeField] private TMP_Text description;
        [SerializeField] private TMP_Text characterName;

        
        protected override void OnInitialize()
        {
            BindToViewModel();
        }

        private void BindToViewModel()
        {
            Model.Description.Subscribe(OnDescriptionChange).AddTo(Disposables);
            Model.Name.Subscribe(OnNameChange).AddTo(Disposables);
            Model.Icon.Subscribe(OnIconChange).AddTo(Disposables);
            Model.Level.Subscribe(OnLevelChange).AddTo(Disposables);
        }
        private void OnDescriptionChange(string newValue)
        {
            description.text = newValue;
        }
        private void OnNameChange(string newValue)
        {
            characterName.text = $"@{newValue}";
        }
        private void OnIconChange(Sprite newValue)
        {
            characterIcon.sprite = newValue;
        }
        private void OnLevelChange(int newValue)
        {
            level.text = $"Level: {newValue}";
        }
    }

 
}