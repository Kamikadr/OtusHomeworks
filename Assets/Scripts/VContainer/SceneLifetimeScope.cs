using ShootEmUp.Bullets;
using ShootEmUp.Common;
using ShootEmUp.Enemies;
using ShootEmUp.Game;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp.DI
{
    public class SceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<Factory<Bullet>>(Lifetime.Singleton).Build();
            builder.Register<Factory<Enemy>>(Lifetime.Singleton).Build();
            builder.Register<Pool<Enemy>>(Lifetime.Singleton).Build();
            builder.Register<Pool<Bullet>>(Lifetime.Singleton).Build();
        }
    }
}
