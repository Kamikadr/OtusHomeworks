using System;
using TMPro;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ViewModels;

namespace Views
{
    public class ProgressBar: BaseView<IProgressBarViewModel>
    {
        [SerializeField] private Slider progressBar;
        [SerializeField] private TMP_Text xpText;
        
        
        private int _currentXp;
        private int _requiredXp;
        protected override void OnInitialize()
        {
            BindToViewModel();
        }

        private void BindToViewModel()
        {
            Model.RequiredXp.Subscribe(OnRequiredXpChange).AddTo(Disposables);
            Model.CurrentXp.Subscribe(OnCurrentXpChange).AddTo(Disposables);
        }

        private void OnCurrentXpChange(int newValue)
        {
            _currentXp = newValue;
            //need animation

            progressBar.value = (float) _currentXp / _requiredXp;

            xpText.text = $"{_currentXp} / {_requiredXp}";
        }
        private void OnRequiredXpChange(int newValue)
        {
            _requiredXp = newValue;
        }
    }
}