using ShootEmUp.Bullets;
using ShootEmUp.Level;
using UnityEngine;
using VContainer.Unity;

namespace VContainer
{
    public class EnvironmentInstaller: Installer
    {
        [SerializeField] private Transform backgroundTransform;
        [SerializeField] private BackgroundMoveConfig backgroundMoveConfig;

        public override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<LevelBounds>().AsSelf();
            builder.RegisterInstance(backgroundMoveConfig);
            builder.Register<LevelBackground>(Lifetime.Singleton).WithParameter(backgroundTransform)
                .AsImplementedInterfaces();
        }
    }
}