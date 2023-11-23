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
        private readonly Queue<T> _bulletPool = new();
        
        private void Awake()
        {
            for (var i = 0; i <= defaultItemCount; i++)
            {
                var newBullet = itemFactory.Create(poolContainer);
                _bulletPool.Enqueue(newBullet);
            }
        }

        public T Get()
        {
            if (_bulletPool.TryDequeue(out var bullet))
            {
                return bullet;
            }

            return itemFactory.Create(poolContainer);
        }

        public void Release(T bullet)
        {
            if (_bulletPool.Count < defaultItemCount)
            {
                bullet.transform.SetParent(poolContainer);
                _bulletPool.Enqueue(bullet);
            }
            else
            {
                Destroy(bullet);
            }
        }
    }
}