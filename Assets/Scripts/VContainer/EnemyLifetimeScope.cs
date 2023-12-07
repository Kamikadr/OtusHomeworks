using ShootEmUp.Enemies;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp.DI
{
    public class EnemyLifetimeScope: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<EnemyMoveAgent>(Lifetime.Transient).AsImplementedInterfaces().AsSelf();        
            builder.Register<EnemyAttackAgent>(Lifetime.Transient).AsImplementedInterfaces().AsSelf();        
            builder.Register<EnemyActionController>(Lifetime.Transient).AsImplementedInterfaces().AsSelf();        
        }
    }
}