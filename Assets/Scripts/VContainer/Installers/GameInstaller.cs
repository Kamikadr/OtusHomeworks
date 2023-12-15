using ShootEmUp.Game;
using UnityEngine;
using VContainer.Unity;

namespace VContainer
{
    public class GameInstaller: Installer
    {
        [SerializeField] private TimerSettings startTimerSettings;
        public override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameManager>();
            builder.Register<GameContext>(Lifetime.Singleton);
            builder.Register<GameCooldownLauncher>(Lifetime.Singleton).WithParameter(startTimerSettings)
                .AsImplementedInterfaces().AsSelf();
        }
    }
}