using UnityEngine;

namespace ShootEmUp.Bullets
{
    public class BulletSystem: MonoBehaviour
    {
        [SerializeField] private BulletSpawnManager bulletSpawnManager;
        [SerializeField] private BulletLifecycleController bulletLifecycleController;
        
        public void FlyBulletByArgs(BulletArgs bulletArgs)
        {
            var bullet = bulletSpawnManager.SpawnBullet(bulletArgs);
            bulletLifecycleController.AddBullet(bullet);
        }
    }
}