using ShootEmUp.Bullets;
using ShootEmUp.Common;
using UnityEngine;

namespace VContainer
{
    public class BulletInstaller: Installer
    {
        [SerializeField] private Transform bulletPoolContainer;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private Bullet bulletPrefab;
        
        public override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(bulletPrefab);
            builder.Register<Factory<Bullet>>(Lifetime.Singleton);
            builder.Register<Pool<Bullet>>(Lifetime.Singleton).WithParameter(50).WithParameter(bulletPoolContainer).AsImplementedInterfaces().AsSelf();
            builder.Register<BulletSpawnManager>(Lifetime.Singleton)
                .AsImplementedInterfaces().AsSelf().WithParameter(worldTransform);
            builder.Register<BulletLifecycleController>(Lifetime.Singleton)
                .AsImplementedInterfaces().AsSelf();
            builder.Register<BulletSystem>(Lifetime.Singleton);
        }
    }
}