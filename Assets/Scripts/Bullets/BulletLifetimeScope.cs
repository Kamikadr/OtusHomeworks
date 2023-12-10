using Game;
using ShootEmUp.Characters;
using ShootEmUp.Common;
using ShootEmUp.Componets;
using ShootEmUp.Enemies;
using ShootEmUp.Game;
using ShootEmUp.GameInput;
using ShootEmUp.Level;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp.Bullets
{
    public class BulletLifetimeScope: LifetimeScope
    {
        [Header("Game settings")]
        [SerializeField] private TimerSettings startTimerSettings;
        
        [Header("Location of objects")]
        [SerializeField] private Transform worldTransform;
        [SerializeField] private Transform bulletPoolContainer;
        [SerializeField] private Transform enemyPoolContainer;
        
        [Header("Prefabs of objects")]
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private Character character;

        [Header("Enemy positions")] 
        [SerializeField] private Transform[] enemySpawnPositions;
        [SerializeField] private Transform[] enemyFirePositions;

        [Space]
        [SerializeField] private float enemySpawnDelay;
        [SerializeField] private int enemyMaxCount;

        [Header("Environment")] 
        [SerializeField] private Transform backgroundTransform;
        [SerializeField] private BackgroundMoveConfig backgroundMoveConfig;
        [SerializeField] private BulletConfig playerBulletConfig;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameManager>();
            builder.Register<GameContext>(Lifetime.Singleton);
            builder.Register<CharacterDeathController>(Lifetime.Singleton);
            builder.Register<GameCooldownLauncher>(Lifetime.Singleton).WithParameter(startTimerSettings)
                .AsImplementedInterfaces().AsSelf();

            RegisterInput(builder);
            RegisterEnvironment(builder);
            RegisterBulletElements(builder);
            RegisterCharacterComponents(builder);
            RegisterEnemyElements(builder);
        }

        private void RegisterInput(IContainerBuilder builder)
        {
            builder.Register<KeyboardInput>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterEnvironment(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<LevelBounds>().AsSelf();
            builder.RegisterInstance(backgroundMoveConfig);
            builder.Register<LevelBackground>(Lifetime.Singleton).WithParameter(backgroundTransform)
                .AsImplementedInterfaces();
        }

        private void RegisterEnemyElements(IContainerBuilder builder)
        {
            /*builder.Register(_ =>
            {
                using (EnqueueParent(this))
                {
                    return Instantiate(enemyPrefab);
                }
            }, Lifetime.Transient);*/
            builder.RegisterInstance(enemyPrefab);
            builder.Register<Factory<Enemy>>(Lifetime.Singleton);
            builder.Register<Pool<Enemy>>(Lifetime.Singleton).WithParameter(enemyPoolContainer);
            builder.RegisterInstance(new EnemyPositions(enemySpawnPositions, enemyFirePositions));
            builder.Register<EnemyCountdownSpawner>(Lifetime.Singleton).WithParameter(enemySpawnDelay)
                .AsImplementedInterfaces().AsSelf();
            builder.Register<EnemyManager>(Lifetime.Singleton).WithParameter(enemyMaxCount);
            builder.Register<EnemySpawner>(Lifetime.Singleton).WithParameter(worldTransform).WithParameter(enemyMaxCount);
        }

        private void RegisterBulletElements(IContainerBuilder builder)
        {
            builder.RegisterInstance(bulletPrefab);
            //builder.RegisterComponentInNewPrefab(bulletPrefab, Lifetime.Transient);
            builder.Register<Factory<Bullet>>(Lifetime.Singleton);
            builder.Register<Pool<Bullet>>(Lifetime.Singleton).WithParameter(bulletPoolContainer);
            builder.Register<BulletSpawnManager>(Lifetime.Singleton)
                .AsImplementedInterfaces().AsSelf().WithParameter(worldTransform);
            builder.Register<BulletLifecycleController>(Lifetime.Singleton)
                .AsImplementedInterfaces().AsSelf();
            builder.Register<BulletSystem>(Lifetime.Singleton);
        }

        private void RegisterCharacterComponents(IContainerBuilder builder)
        {
            builder.RegisterComponent(character).AsImplementedInterfaces().AsSelf();
            builder.Register<CharacterDeathObserver>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.RegisterComponentInHierarchy<HitPointsComponent>().AsImplementedInterfaces().AsSelf();
            builder.RegisterComponentInHierarchy<MoveRigidbodyComponent>().AsImplementedInterfaces().AsSelf();
            builder.Register<CharacterFireController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<CharacterMoveController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.RegisterInstance(playerBulletConfig);
        }
    }
}