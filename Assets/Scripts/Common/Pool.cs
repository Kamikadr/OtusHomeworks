using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Common
{
    public class Pool<T> where T: MonoBehaviour
    {
        private readonly Factory<T> _itemFactory;
        private readonly Transform _poolContainer;
        private readonly Queue<T> _pool = new();
        private int _defaultItemCount;

        public Pool(Factory<T> itemFactory, Transform poolContainer)
        {
            _itemFactory = itemFactory;
            _poolContainer = poolContainer;
        }
        private void Initialize(int defaultItemCount)
        {
            _defaultItemCount = defaultItemCount;
            for (var i = 0; i < defaultItemCount; i++)
            {
                var newBullet = _itemFactory.Create(_poolContainer);
                _pool.Enqueue(newBullet);
            }
        }

        public T Get()
        {
            if (_pool.TryDequeue(out var item))
            {
                return item;
            }

            return _itemFactory.Create(_poolContainer);
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