using UnityEngine;

namespace Views
{
    public class ViewFactory<T> where T: MonoBehaviour
    {
        private readonly T _viewPrefab;
        public ViewFactory(T viewPrefab)
        {
            _viewPrefab = viewPrefab;
        }

        public T Create(Transform parent)
        {
            return Object.Instantiate(_viewPrefab, parent);
        }
    }
}