using System.Collections.Generic;
using ShootEmUp.Level;
using UnityEngine;

namespace ShootEmUp.Bullets
{
    public class BulletLifecycleController: MonoBehaviour
    {
        [SerializeField] private LevelBounds levelBounds;
        [SerializeField] private BulletSpawnManager bulletSpawnManager;
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();
        

        public void AddBullet(Bullet bullet)
        {
            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }
        private void FixedUpdate()
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
        
        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                bulletSpawnManager.RemoveBullet(bullet);
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            RemoveBullet(bullet);
        }
    }
}