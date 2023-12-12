using System;
using UI;
using UnityEngine;
using UnityEngine.UI;
using ViewModels;
using UniRx;
using UnityEngine.Serialization;

namespace Views
{
    public class CharacterPopupView: MonoBehaviour
    {
        [SerializeField] private LevelButton levelButton;
        [SerializeField] private Button button;
        [FormerlySerializedAs("characterInfoView")] [SerializeField] private UserInfoView userInfoView;
        [SerializeField] private ProgressBar progressBar;
        [SerializeField] private CharacterStatView characterStatView;

        private IPopupViewModel _model;
        private CompositeDisposable _compositeDisposable;


        public void Initialize(object viewModel)
        {
            if (viewModel is not IPopupViewModel popupViewModel)
            {
                throw new Exception("Expected IPopupViewModel");
            }
            
            _model = popupViewModel;
            BindToViewModel();
            
            userInfoView.Initialize(popupViewModel.UserInfoViewModel);
            progressBar.Initialize(popupViewModel.CharacterProgressBarViewModel);
            characterStatView.Initialize(popupViewModel.CharacterInfoViewModel);
        }

        private void BindToViewModel()
        {
            _compositeDisposable = new CompositeDisposable();
            _model.CanLevelUp.Subscribe(UpdateLevelButton).AddTo(_compositeDisposable);
            _model.LevelUpCommand.BindTo(levelButton.Button).AddTo(_compositeDisposable);
        }


        private void UpdateLevelButton(bool value)
        {
            levelButton.SetInteractable(value);
        }

        private void OnDestroy()
        {
            _compositeDisposable.Dispose();
            _compositeDisposable = null;
        }
    }
}