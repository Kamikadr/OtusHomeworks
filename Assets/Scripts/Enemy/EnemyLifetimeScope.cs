using ShootEmUp.Bullets;
using ShootEmUp.Componets;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp.Enemies
{
    public class EnemyLifetimeScope: LifetimeScope
    {
        [SerializeField] private Transform enemyTransform;
        [SerializeField] private BulletConfig bulletConfig;
        [SerializeField] private float enemyAttackCooldown;
        [SerializeField] private float enemyMoveThreshold;
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterComponents(builder);
            RegisterAttackElements(builder);
            RegisterMoveElements(builder);
        }

        private void RegisterMoveElements(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<EnemyMoveAgent>()
                .WithParameter(enemyMoveThreshold)
                .WithParameter(enemyTransform)
                .AsImplementedInterfaces().AsSelf();
        }

        private void RegisterComponents(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<HitPointsComponent>();
            builder.RegisterComponentInHierarchy<WeaponComponent>();
            builder.RegisterComponentInHierarchy<MoveRigidbodyComponent>()
                .AsImplementedInterfaces().As<MoveComponent>();
        }

        private void RegisterAttackElements(IContainerBuilder builder)
        {
            builder.RegisterInstance(bulletConfig);
            builder.RegisterComponentInHierarchy<EnemyAttackAgent>();
            
            builder.Register<FireSetup>(Lifetime.Singleton);
            builder.Register<CooldownCounter>(Lifetime.Singleton)
                .WithParameter(enemyAttackCooldown)
                .AsImplementedInterfaces().AsSelf();
            builder.Register<EnemyAttackController>(Lifetime.Singleton);
        }
    }
}