using System;
using TMPro;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ViewModels;

namespace Views
{
    public class ProgressBar: MonoBehaviour
    {
        [SerializeField] private Slider progressBar;
        [SerializeField] private TMP_Text xpText;

        private IProgressBarViewModel _model;
        private CompositeDisposable _disposable;
        
        private int _currentXp;
        private int _requiredXp;
        public void Initialize(object obj)
        {
            if (obj is not IProgressBarViewModel progressBarViewModel)
            {
                throw new Exception("Expected CharacterProgressBarViewModel");
            }

            _model = progressBarViewModel;
            BindToViewModel();
        }

        private void BindToViewModel()
        {
            _disposable = new CompositeDisposable();
            
            _model.RequiredXp.Subscribe(OnRequiredXpChange).AddTo(_disposable);
            _model.CurrentXp.Subscribe(OnCurrentXpChange).AddTo(_disposable);
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