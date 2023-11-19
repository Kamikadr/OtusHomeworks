using System.Collections.Generic;
using ShootEmUp.Common;
using ShootEmUp.Level;
using UnityEngine;

namespace ShootEmUp.Bullets
{
    public sealed class BulletSystem : MonoBehaviour, IBulletSystem
    {
       [SerializeField] private Transform worldTransform;
       [SerializeField] private LevelBounds levelBounds;
       [SerializeField] private int initialBulletCount;

       private readonly HashSet<Bullet> _activeBullets = new();
       private readonly List<Bullet> _cache = new();
       private Pool<Bullet> _bulletPool;


       public void Initialize(Pool<Bullet> bulletPool)
       {
           _bulletPool = bulletPool;
           _bulletPool.Initialize(initialBulletCount);
       }
       
       
       public void FixedUpdate()
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                if (!levelBounds.InBounds(bullet.GetPosition()))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(BulletArgs bulletArgs)
        {

            var bullet = _bulletPool.Get();
            bullet.SetParent(worldTransform);
            bullet.SetBulletArgs(bulletArgs);
            
            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                _bulletPool.Release(bullet);
            }
        }
    }
}