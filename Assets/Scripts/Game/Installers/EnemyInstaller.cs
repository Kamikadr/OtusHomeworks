﻿using ShootEmUp.Bullets;
using ShootEmUp.Characters;
using ShootEmUp.Common;
using ShootEmUp.Enemies;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Game.Installers
{
    [DefaultExecutionOrder(-1)]
    public class EnemyInstaller: MonoBehaviour
    {
        [SerializeField] private BulletFacade bulletSystem;
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