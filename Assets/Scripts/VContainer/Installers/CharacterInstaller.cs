using Game;
using ShootEmUp.Bullets;
using ShootEmUp.Characters;
using UnityEngine;
using VContainer.Unity;

namespace VContainer
{
    public class CharacterInstaller:Installer
    {
        [SerializeField] private Character character;
        [SerializeField] private BulletConfig playerBulletConfig;
        
        public override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(character).AsImplementedInterfaces().AsSelf();
            builder.Register<CharacterDeathObserver>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<CharacterDeathController>(Lifetime.Singleton);
            builder.Register<CharacterFireController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<CharacterMoveController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.RegisterInstance(playerBulletConfig);
        }
    }
}