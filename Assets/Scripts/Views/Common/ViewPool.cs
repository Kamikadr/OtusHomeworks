using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class ViewPool<T> where T: MonoBehaviour
    {
        private readonly ViewFactory<T> _factory;
        private readonly Transform _poolContainer;
        
        private int _defaultItemCount;
        private readonly Queue<T> _pool = new();

        public ViewPool(ViewFactory<T> factory, Transform poolContainer)
        {
            _factory = factory;
            _poolContainer = poolContainer;
        }

        public void Initialize(int itemCount)
        {
            _defaultItemCount = itemCount;

            for (int i = 0; i < _defaultItemCount; i++)
            {
                var item = _factory.Create(_poolContainer);
                _pool.Enqueue(item);
            }
        }

        public T Get(Transform parent)
        {
            if (_pool.TryDequeue(out var result))
            {
                result.transform.SetParent(parent);
                return result;
            }

            return _factory.Create(parent);
        }
        
        
        public void Release(T item)
        {
            if (_pool.Count < _defaultItemCount)
            {
                item.transform.SetParent(_poolContainer);
                _pool.Enqueue(item);
            }
            else
            {
                Object.Destroy(item.gameObject);
            }
        }
    }
}