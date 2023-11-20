using ShootEmUp.Bullets;
using ShootEmUp.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Game.Installers
{
    public class BulletInstaller: MonoBehaviour
    {
        [SerializeField] private BulletSpawnManager bulletSpawnManager;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletPoolTransform;
        private void Awake()
        {
            var bulletFactory = new Factory<Bullet>(bulletPrefab);
            var bulletPool = new Pool<Bullet>(bulletFactory, bulletPoolTransform);
            bulletSpawnManager.Initialize(bulletPool);
        }
    }
}