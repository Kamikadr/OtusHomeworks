using UnityEngine;

namespace Views
{
    public class CharacterStatViewFactory
    {
        private readonly CharacterStatView _viewPrefab;
        public CharacterStatViewFactory(CharacterStatView viewPrefab)
        {
            _viewPrefab = viewPrefab;
        }

        public CharacterStatView Create(Transform parent)
        {
            return Object.Instantiate(_viewPrefab, parent);
        }
    }
}