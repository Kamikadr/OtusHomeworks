using ShootEmUp.Common;
using UnityEngine;

namespace ShootEmUp.Bullets
{
    public sealed class BulletSpawnManager
    {
       private readonly Transform _worldTransform;
       private readonly Pool<Bullet> _bulletPool;

       public BulletSpawnManager(Pool<Bullet> bulletPool, Transform worldTransform)
       {
           _bulletPool = bulletPool;
           _worldTransform = worldTransform;
           Debug.Log("BulletSpawnManager");
       }
       
       public Bullet SpawnBullet(BulletArgs bulletArgs)
        {
            var bullet = _bulletPool.Get();
            bullet.SetParent(_worldTransform);
            bullet.SetBulletArgs(bulletArgs);
            return bullet;
        }
        
        public void RemoveBullet(Bullet bullet)
        {
            _bulletPool.Release(bullet);
        }
    }
}