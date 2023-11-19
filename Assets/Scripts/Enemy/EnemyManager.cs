using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private int maxEnemyCount;
        
        private readonly HashSet<GameObject> _activeEnemies = new();
        
        private EnemyBulletArgsFactory _bulletArgsFactory;
        private EnemySpawner _enemySpawner;
        private IBulletSystem _bulletSystem;

        public void Initialize(IBulletSystem bulletSystem, EnemyBulletArgsFactory bulletArgsFactory, EnemySpawner enemySpawner)
        {
            _bulletSystem = bulletSystem;
            _bulletArgsFactory = bulletArgsFactory;
            _enemySpawner = enemySpawner;
        }
        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                if (_activeEnemies.Count < maxEnemyCount)
                {
                    var enemy = _enemySpawner.SpawnEnemy();
                    if (_activeEnemies.Add(enemy.gameObject))
                    {
                        enemy.hitPointsComponent.HpIsEmptyEvent += OnDestroyed;
                        enemy.enemyAttackAgent.OnFire += OnFire;
                    }
                }
            }
        }

        private void OnDestroyed(GameObject enemyGameObject)
        {
            if (_activeEnemies.Remove(enemyGameObject))
            {
                var enemy = enemyGameObject.GetComponent<Enemy>();
                enemy.hitPointsComponent.HpIsEmptyEvent -= OnDestroyed;
                enemy.enemyAttackAgent.OnFire -= OnFire;
                _enemySpawner.UnspawnEnemy(enemy);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            var bulletArgs = _bulletArgsFactory.Create(position, direction);
            _bulletSystem.FlyBulletByArgs(bulletArgs);
        }
    }
}