using System;
using TMPro;
using UniRx;
using UnityEngine;
using ViewModels;

namespace Views
{
    public class CharacterStatView: BaseView<ICharacterStatViewModel>
    {
        [SerializeField] private TMP_Text statName;
        [SerializeField] private TMP_Text statValue;

        protected override void OnInitialize()
        {
            Model.Value.Subscribe(OnValueChange).AddTo(Disposables);
            statName.text = Model.Name;
        }

        private void OnValueChange(int newValue)
        {
            statValue.text = newValue.ToString();
        }
    }
}