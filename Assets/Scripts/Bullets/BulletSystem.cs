using UnityEngine;

namespace ShootEmUp.Bullets
{
    public class BulletSystem
    {
        private readonly BulletSpawnManager _bulletSpawnManager;
        private readonly BulletLifecycleController _bulletLifecycleController;
        
        public BulletSystem(BulletSpawnManager bulletSpawnManager, BulletLifecycleController bulletLifecycleController)
        {
            _bulletSpawnManager = bulletSpawnManager;
            _bulletLifecycleController = bulletLifecycleController;
        }
        public void FlyBulletByArgs(BulletArgs bulletArgs)
        {
            var bullet = _bulletSpawnManager.SpawnBullet(bulletArgs);
            _bulletLifecycleController.AddBullet(bullet);
        }
    }
}