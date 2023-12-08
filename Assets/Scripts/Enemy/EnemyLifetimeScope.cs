using ShootEmUp.Bullets;
using ShootEmUp.Componets;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp.Enemies
{
    
    public class EnemyLifetimeScope: LifetimeScope
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private BulletConfig bulletConfig;
        [SerializeField] private float enemyAttackCooldown;
        [SerializeField] private float enemyMoveThreshold;
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterAttackElements(builder);
            RegisterComponents(builder);
            RegisterMoveElements(builder);
        }

        private void RegisterMoveElements(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<EnemyMoveAgent>().
                WithParameter(enemyMoveThreshold).
                WithParameter(enemy.transform).
                AsImplementedInterfaces().AsSelf();
        }

        private void RegisterComponents(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<HitPointsComponent>();
            builder.RegisterComponentInHierarchy<MoveComponent>();
            builder.RegisterComponentInHierarchy<WeaponComponent>();
        }

        private void RegisterAttackElements(IContainerBuilder builder)
        {
            builder.RegisterInstance(bulletConfig);
            builder.RegisterComponentInHierarchy<EnemyAttackAgent>();
            
            builder.Register<FireSetup>(Lifetime.Singleton);
            builder.Register<CooldownCounter>(Lifetime.Singleton).WithParameter(enemyAttackCooldown);
            builder.Register<EnemyAttackController>(Lifetime.Singleton);
        }
    }
}