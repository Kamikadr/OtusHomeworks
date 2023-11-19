using ShootEmUp.Bullets;
using ShootEmUp.Common;
using UnityEngine;

namespace ShootEmUp.Game.Installers
{
    public class BulletInstaller: MonoBehaviour
    {
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletPoolTransform;
        private void Awake()
        {
            var bulletFactory = new Factory<Bullet>(bulletPrefab);
            var bulletPool = new Pool<Bullet>(bulletFactory, bulletPoolTransform);
            bulletSystem.Initialize(bulletPool);
        }
    }
}