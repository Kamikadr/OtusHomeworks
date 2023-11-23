using ShootEmUp.Common;
using UnityEngine;

namespace ShootEmUp.Bullets
{
    public sealed class BulletSpawnManager : MonoBehaviour
    {
       [SerializeField] private Transform worldTransform;
       [SerializeField] private Pool<Bullet> bulletPool;
       
       
       public Bullet SpawnBullet(BulletArgs bulletArgs)
        {
            var bullet = bulletPool.Get();
            bullet.SetParent(worldTransform);
            bullet.SetBulletArgs(bulletArgs);
            return bullet;
        }
        
        public void RemoveBullet(Bullet bullet)
        {
            bulletPool.Release(bullet);
        }
    }
}