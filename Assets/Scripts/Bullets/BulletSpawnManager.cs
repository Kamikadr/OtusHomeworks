using ShootEmUp.Common;
using UnityEngine;

namespace ShootEmUp.Bullets
{
    public sealed class BulletSpawnManager : MonoBehaviour
    {
       [SerializeField] private Transform worldTransform;
       [SerializeField] private int initialBulletCount;
       private Pool<Bullet> _bulletPool;


       public void Initialize(Pool<Bullet> bulletPool)
       {
           _bulletPool = bulletPool;
           _bulletPool.Initialize(initialBulletCount);
       }
       

        public Bullet SpawnBullet(BulletArgs bulletArgs)
        {
            var bullet = _bulletPool.Get();
            bullet.SetParent(worldTransform);
            bullet.SetBulletArgs(bulletArgs);
            return bullet;
        }
        
        public void RemoveBullet(Bullet bullet)
        {
            _bulletPool.Release(bullet);
        }
    }
}