using System.Collections.Generic;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer.Unity;

namespace ShootEmUp.Common
{
    public class Pool<T>: IStartable where T: MonoBehaviour
    {
        private readonly Factory<T> _itemFactory;
        private readonly Transform _poolContainer;
        private readonly Queue<T> _pool = new();
        private readonly int _defaultItemCount;

        
        public Pool(Factory<T> itemFactory, Transform poolContainer, int defaultItemCount)
        {
            _itemFactory = itemFactory;
            _poolContainer = poolContainer;
            _defaultItemCount = defaultItemCount;
        }
        void IStartable.Start()
        {
            for (var i = 0; i < _defaultItemCount; i++)
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