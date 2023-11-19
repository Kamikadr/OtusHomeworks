using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Common
{
    public class Pool<T> where T: MonoBehaviour
    {
        private int _defaultItemCount;
        private readonly Factory<T> _itemFactory;
        private readonly Queue<T> _bulletPool = new();
        private readonly Transform _poolContainer;

        public Pool(Factory<T> factory, Transform poolContainer)
        {
            _itemFactory = factory;
            _poolContainer = poolContainer;
        }
        public void Initialize(int defaultItemCount)
        {
            _defaultItemCount = defaultItemCount;
            for (var i = 0; i <= _defaultItemCount; i++)
            {
                var newBullet = _itemFactory.Create(_poolContainer);
                _bulletPool.Enqueue(newBullet);
            }
        }

        public T Get()
        {
            if (_bulletPool.TryDequeue(out var bullet))
            {
                return bullet;
            }

            return _itemFactory.Create(_poolContainer);
        }

        public void Release(T bullet)
        {
            if (_bulletPool.Count < _defaultItemCount)
            {
                bullet.transform.SetParent(_poolContainer);
                _bulletPool.Enqueue(bullet);
            }
            else
            {
                Object.Destroy(bullet);
            }
        }
    }
}