using System;
using UI;
using UnityEngine;
using UnityEngine.UI;
using ViewModels;
using UniRx;
using UnityEngine.Serialization;

namespace Views
{
    public class CharacterPopupView: BaseView<IPopupViewModel>
    {
        [SerializeField] private LevelButton levelButton;
        [SerializeField] private Button button;
        [SerializeField] private UserInfoView userInfoView;
        [SerializeField] private ProgressBar progressBar;
        [SerializeField] private CharacterInfoView characterInfoView;
        


        protected override void OnInitialize()
        {
            BindToViewModel();
            userInfoView.Initialize(Model.UserInfoViewModel);
            progressBar.Initialize(Model.CharacterProgressBarViewModel);
            characterInfoView.Initialize(Model.CharacterInfoViewModel);
        }

        private void BindToViewModel()
        {
            Model.CanLevelUp.Subscribe(UpdateLevelButton).AddTo(Disposables);
            Model.LevelUpCommand.BindTo(levelButton.Button).AddTo(Disposables);
        }


        private void UpdateLevelButton(bool value)
        {
            levelButton.SetInteractable(value);
        }
    }
}