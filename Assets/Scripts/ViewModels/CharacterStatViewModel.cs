using System;
using Lessons.Architecture.PM;
using UniRx;

namespace ViewModels
{
    public class CharacterStatViewModel:ICharacterStatViewModel, IDisposable
    {
        public IReadOnlyReactiveProperty<int> Value => _value;
        public string Name { get; }

        private readonly ReactiveProperty<int> _value;
        private readonly CharacterStat _characterStat;
        
        public CharacterStatViewModel(CharacterStat characterStat)
        {
            _characterStat = characterStat;
            Name = _characterStat.Name;
            _characterStat.OnValueChanged += OnStatValueChanged;

            _value = new ReactiveProperty<int>(_characterStat.Value);
        }

        private void OnStatValueChanged(int newValue)
        {
            _value.Value = newValue;
        }

        public void Dispose()
        {
            _characterStat.OnValueChanged -= OnStatValueChanged;
        }
    }
}