using ShootEmUp.Common;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform worldTransform;
        [SerializeField] private int initializeEnemyCount;
        private Pool<Enemy> _enemyPool;

        public void Initialize(Pool<Enemy> enemyPool)
        {
            _enemyPool = enemyPool;
            _enemyPool.Initialize(initializeEnemyCount);
        }
  

        public Enemy SpawnEnemy()
        {
            var enemy = _enemyPool.Get();

            enemy.SetParent(worldTransform);
            return enemy;
        }

        public void UnspawnEnemy(Enemy enemy)
        {
            _enemyPool.Release(enemy);
        }
    }
}