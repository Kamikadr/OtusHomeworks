using System;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyInstaller: MonoBehaviour
    {
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private EnemyManager enemyManager;
        [SerializeField] private BulletConfig bulletConfig;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private Character character;
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private Transform poolContainer;


        private void Awake()
        {
            var enemyFactory = new EnemyFactory(enemyPrefab, character, enemyPositions);
            var enemyPool = new Pool<Enemy>(enemyFactory, poolContainer);
            enemySpawner.Initialize(enemyPool);
            
            var bulletArgsFactory = new EnemyBulletArgsFactory(bulletConfig);
            enemyManager.Initialize(bulletSystem, bulletArgsFactory, enemySpawner);
        }
    }
}