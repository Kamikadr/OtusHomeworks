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
        
        [Header("Enemy Components")]
        [SerializeField] private HitPointsComponent hitPointsComponent;
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private MoveComponent moveComponent;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(enemy);
            
            RegisterComponents(builder);
            RegisterAttackElements(builder);
            RegisterMoveElements(builder);
        }

        private void RegisterMoveElements(IContainerBuilder builder)
        {
            builder.Register<EnemyMoveAgent>(Lifetime.Singleton)
                .WithParameter(enemyMoveThreshold)
                .WithParameter(enemy.transform)
                .AsImplementedInterfaces().AsSelf();
        }

        private void RegisterComponents(IContainerBuilder builder)
        {
            builder.RegisterInstance(hitPointsComponent);
            builder.RegisterInstance(weaponComponent);
            builder.RegisterInstance(moveComponent);
        }

        private void RegisterAttackElements(IContainerBuilder builder)
        {
            builder.RegisterInstance(bulletConfig);
            builder.Register<EnemyAttackAgent>(Lifetime.Singleton);
            
            builder.Register<FireSetup>(Lifetime.Singleton);
            builder.Register<CooldownCounter>(Lifetime.Singleton)
                .WithParameter(enemyAttackCooldown)
                .AsImplementedInterfaces().AsSelf();
            builder.Register<EnemyAttackController>(Lifetime.Singleton);
        }
    }
}