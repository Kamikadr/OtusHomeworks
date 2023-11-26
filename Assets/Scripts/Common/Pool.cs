using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Common
{
    public class Pool<T>: MonoBehaviour where T: MonoBehaviour
    {
        [SerializeField] private int defaultItemCount;
        [SerializeField] private Factory<T> itemFactory;
        [SerializeField] private Transform poolContainer;
        private readonly Queue<T> _pool = new();
        
        private void Awake()
        {
            for (var i = 0; i < defaultItemCount; i++)
            {
                var newBullet = itemFactory.Create(poolContainer);
                _pool.Enqueue(newBullet);
            }
        }

        public T Get()
        {
            if (_pool.TryDequeue(out var item))
            {
                return item;
            }

            return itemFactory.Create(poolContainer);
        }

        public void Release(T item)
        {
            if (_pool.Count < defaultItemCount)
            {
                item.transform.SetParent(poolContainer);
                _pool.Enqueue(item);
            }
            else
            {
                Destroy(item.gameObject);
            }
        }
    }
}