using ShootEmUp.Characters;
using ShootEmUp.Common;
using ShootEmUp.GameInput;
using ShootEmUp.Level;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp.Bullets
{
    public class BulletLifetimeScope: LifetimeScope
    {
        [SerializeField] private Transform worldTransform;
        [SerializeField] private Transform poolContainer;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Character character;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<KeyboardInput>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.Register<Factory<Bullet>>(Lifetime.Singleton);
            builder.Register<Pool<Bullet>>(Lifetime.Singleton).WithParameter(poolContainer);
            builder.RegisterComponentInHierarchy<LevelBounds>().AsSelf();
            
            builder.Register<BulletSpawnManager>(Lifetime.Singleton)
                .AsImplementedInterfaces().AsSelf().WithParameter(worldTransform);
            builder.Register<BulletLifecycleController>(Lifetime.Singleton)
                .AsImplementedInterfaces().AsSelf();
            builder.Register<BulletSystem>(Lifetime.Singleton);
            
            builder.RegisterComponentInNewPrefab(bulletPrefab, Lifetime.Transient);

            RegisterCharacterComponents(builder);

        }

        private void RegisterCharacterComponents(IContainerBuilder builder)
        {
            builder.RegisterComponent(character).AsImplementedInterfaces().AsSelf();
            builder.Register<CharacterDeathObserver>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CharacterFireController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<CharacterMoveController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }
    }
}