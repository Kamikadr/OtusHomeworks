using Lessons.Architecture.PM;
using ViewModels;
using Views;

namespace Lessons.Architecture
{
    public class PopupManager
    {
        private readonly CharacterPopupView _characterPopupView;
        private PopupViewModel _characterPopupViewModel;
        
        public PopupManager(CharacterPopupView characterPopupView)
        {
            _characterPopupView = characterPopupView;
        }

        public void ShowPopup(PlayerLevel playerLevel, CharacterInfo characterInfo, UserInfo userInfo)
        {
            if (_characterPopupViewModel != null)
            {
                return;
            }
            
            _characterPopupViewModel = new PopupViewModel(playerLevel, characterInfo, userInfo);
            _characterPopupView.Initialize(_characterPopupViewModel);
            _characterPopupViewModel.OnPopupHide += OnPopupHide;
        }
        private void OnPopupHide()
        {
            _characterPopupViewModel.OnPopupHide -= OnPopupHide;
            _characterPopupViewModel.Dispose();
            _characterPopupViewModel = null;
        }
    }
}