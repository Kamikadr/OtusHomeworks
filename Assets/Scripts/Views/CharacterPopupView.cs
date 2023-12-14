using UI;
using UnityEngine;
using UnityEngine.UI;
using ViewModels;
using UniRx;

namespace Views
{
    public class CharacterPopupView: BaseView<IPopupViewModel>
    {
        [SerializeField] private LevelButton levelButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private UserInfoView userInfoView;
        [SerializeField] private ProgressBar progressBar;
        [SerializeField] private CharacterInfoView characterInfoView;

        private void OnEnable()
        {
            closeButton.onClick.AddListener(Hide);
        }
        private void Show()
        {
            gameObject.SetActive(true);
        }
        private void Hide()
        {
            gameObject.SetActive(false);
        }

        protected override void OnInitialize()
        {
            BindToViewModel();
            userInfoView.Initialize(Model.UserInfoViewModel);
            progressBar.Initialize(Model.CharacterProgressBarViewModel);
            characterInfoView.Initialize(Model.CharacterInfoViewModel);
            Show();
        }

        private void BindToViewModel()
        {
            Model.CanLevelUp.Subscribe(UpdateLevelButton).AddTo(Disposables);
            Model.LevelUpCommand.BindTo(levelButton.Button).AddTo(Disposables);
            Model.HideCommand.BindTo(closeButton).AddTo(Disposables);
        }


        private void UpdateLevelButton(bool value)
        {
            levelButton.SetInteractable(value);
        }
        
        private void OnDisable()
        {
            closeButton.onClick.RemoveListener(Hide);
        }
    }
}