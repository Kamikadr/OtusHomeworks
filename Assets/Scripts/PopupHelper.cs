using System;
using Lessons.Architecture.PM;
using UnityEngine;
using ViewModels;
using Views;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

namespace Lessons.Architecture
{
    public class PopupHelper: MonoBehaviour
    {
        [SerializeField] private CharacterPopupView characterPopupView;
        [SerializeField] private CharacterInfo characterInfo;
        [SerializeField] private PlayerLevel playerLevel;
        [SerializeField] private UserInfo userInfo;

        private void Awake()
        {
            var characterPopupViewModel = new PopupViewModel(playerLevel, characterInfo, userInfo);
            characterPopupView.Initialize(characterPopupViewModel);
        }
    }
}