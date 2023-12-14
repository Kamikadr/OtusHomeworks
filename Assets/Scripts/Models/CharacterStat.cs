using System;
using Sirenix.OdinInspector;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class CharacterStat
    {
        public event Action<int> OnValueChanged; 

        [ShowInInspector]
        public string Name { get; private set; }

        [ShowInInspector]
        public int Value { get; private set; }

        [Button]
        public void ChangeValue(int value)
        {
            Value = value;
            OnValueChanged?.Invoke(value);
        }
    }
}