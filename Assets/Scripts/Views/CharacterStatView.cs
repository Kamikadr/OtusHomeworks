using System;
using TMPro;
using UniRx;
using UnityEngine;
using ViewModels;

namespace Views
{
    public class CharacterStatView: MonoBehaviour
    {
        [SerializeField] private TMP_Text statName;
        [SerializeField] private TMP_Text statValue;
        
        private ICharacterStatViewModel _model;
        private CompositeDisposable _disposable;
        public void Initialize(object obj)
        {
            if (obj is not ICharacterStatViewModel characterStatView)
            {
                throw new Exception("Expected ICharacterStatViewModel");
            }

            _model = characterStatView;
            _disposable = new CompositeDisposable();
            _model.Value.Subscribe(OnValueChange).AddTo(_disposable);
            statName.text = _model.Name;
        }

        private void OnValueChange(int newValue)
        {
            statValue.text = newValue.ToString();
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}