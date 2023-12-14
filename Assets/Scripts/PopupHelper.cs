using System;
using Lessons.Architecture.PM;
using UnityEngine;
using ViewModels;
using Views;
using Zenject;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

namespace Lessons.Architecture
{
    public class PopupHelper: MonoBehaviour
    {
        [SerializeField] private CharacterInfo characterInfo;
        [SerializeField] private PlayerLevel playerLevel;
        [SerializeField] private UserInfo userInfo;
        [Header("First Popup Settings")]
        [SerializeField] private string cname;
        [SerializeField] private Sprite icon;
        [SerializeField] private string desc;
        private PopupManager _popupManager;

        [Inject]
        private void Construct(PopupManager popupManager)
        {
            _popupManager = popupManager;
        }

        private void Awake()
        {
            userInfo = new UserInfo(cname, desc, icon);
            characterInfo.AddStat(new CharacterStat("Move Speed", 20));
            characterInfo.AddStat(new CharacterStat("Stamina", 10));
            characterInfo.AddStat(new CharacterStat("Damage", 7));
            characterInfo.AddStat(new CharacterStat("Regeneration", 5));
            characterInfo.AddStat(new CharacterStat("Dexterity", 30));
            characterInfo.AddStat(new CharacterStat("Intelligence", 50));
            
            
            _popupManager.ShowPopup(playerLevel, characterInfo, userInfo);
        }
    }
}