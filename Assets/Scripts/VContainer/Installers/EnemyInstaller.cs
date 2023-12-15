using ShootEmUp;
using ShootEmUp.Common;
using ShootEmUp.Enemies;
using UnityEngine;
using VContainer.Unity;

namespace VContainer
{
    public class EnemyInstaller: Installer
    {
        [SerializeField] private Enemy enemyPrefab;
        [Header("Enemy positions")] 
        [SerializeField] private Transform[] enemySpawnPositions;
        [SerializeField] private Transform[] enemyFirePositions;
        [Header("Enemy spawn settings")]
        [SerializeField] private float enemySpawnDelay;
        [SerializeField] private int enemyMaxCount;
        [SerializeField] private Transform enemyPoolContainer;
        [SerializeField] private Transform worldTransform;
        public override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(enemyPrefab);
            builder.Register<Factory<Enemy>>(Lifetime.Singleton).WithParameter(this);
            builder.Register<Pool<Enemy>>(Lifetime.Singleton).WithParameter(enemyPoolContainer).WithParameter(enemyMaxCount).AsImplementedInterfaces().AsSelf();
            builder.RegisterInstance(new EnemyPositions(enemySpawnPositions, enemyFirePositions));
            builder.Register<EnemyCountdownSpawner>(Lifetime.Singleton).WithParameter(enemySpawnDelay)
                .AsImplementedInterfaces().AsSelf();
            builder.Register<EnemyManager>(Lifetime.Singleton).WithParameter(enemyMaxCount).AsImplementedInterfaces().AsSelf();
            builder.Register<EnemySpawner>(Lifetime.Singleton).WithParameter(worldTransform).WithParameter(enemyMaxCount);
            
            
        }
    }
}