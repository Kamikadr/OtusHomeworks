using System;
using UnityEngine;

namespace ShootEmUp.Bullets
{
    public class BulletFacade: MonoBehaviour, IBulletSystem
    {
        [SerializeField] private BulletSpawnManager bulletSpawnManager;
        [SerializeField] private BulletLifecycleController bulletLifecycleController;
        private readonly BulletDamager _bulletDamager = new();
        

        private void OnEnable()
        {
            bulletLifecycleController.OnBulletLifecycleEnd += DeleteBullet;
            bulletLifecycleController.OnBulletCollide += DealDamage;
        }
        
        public void FlyBulletByArgs(BulletArgs bulletArgs)
        {
            var bullet = bulletSpawnManager.SpawnBullet(bulletArgs);
            bulletLifecycleController.AddBullet(bullet);
        }

        private void DealDamage(Bullet bullet, Collision2D collision)
        {
            _bulletDamager.DealDamage(bullet, collision.gameObject);
            DeleteBullet(bullet);
        }

        private void DeleteBullet(Bullet bullet)
        {
            bulletSpawnManager.RemoveBullet(bullet);
        }
        
        private void OnDisable()
        {
            bulletLifecycleController.OnBulletLifecycleEnd -= DeleteBullet;
            bulletLifecycleController.OnBulletCollide -= DealDamage;
        }
    }
}