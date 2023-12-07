using System.Collections.Generic;
using ShootEmUp.Game.Interfaces.GameCycle;
using ShootEmUp.Level;
using UnityEngine;

namespace ShootEmUp.Bullets
{
    public class BulletLifecycleController: IFixedUpdateListener, IGameFinishListener
    {
        private readonly LevelBounds _levelBounds;
        private readonly BulletSpawnManager _bulletSpawnManager;
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();
        
        public BulletLifecycleController(LevelBounds levelBounds, BulletSpawnManager bulletSpawnManager)
        {
            _levelBounds = levelBounds;
            _bulletSpawnManager = bulletSpawnManager;
            Debug.Log("BulletLifecycleController");
        }

        public void AddBullet(Bullet bullet)
        {
            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }
        public void OnFixedUpdate(float deltaTime)
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                if (!_levelBounds.InBounds(bullet.GetPosition()))
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
                _bulletSpawnManager.RemoveBullet(bullet);
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            RemoveBullet(bullet);
        }

        public void OnFinish()
        {
            foreach (var bullet in _activeBullets)
            {
                _bulletSpawnManager.RemoveBullet(bullet);
            }
            _activeBullets.Clear();
        }
    }
}