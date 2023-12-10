using ShootEmUp.Characters;
using ShootEmUp.Common;
using ShootEmUp.Game;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public sealed class EnemySpawner
    {
        private readonly Character _character;
        private readonly Transform _worldTransform;
        private readonly Pool<Enemy> _enemyPool;
        private readonly EnemyPositions _enemyPositions;

        public EnemySpawner(Character character,
            Pool<Enemy> enemyPool,
            EnemyPositions enemyPositions,
            Transform worldTransform,
            int defaultEnemyCount)
        {
            _character = character;
            _enemyPool = enemyPool;
            _enemyPositions = enemyPositions;
            _worldTransform = worldTransform;
            
            _enemyPool.Initialize(defaultEnemyCount);
        }

        public Enemy SpawnEnemy()
        {
            var enemy = _enemyPool.Get();
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            var attackPosition = _enemyPositions.RandomAttackPosition();
            
            enemy.SetParent(_worldTransform);
            enemy.SetPosition(spawnPosition.position);
            enemy.SetDestination(attackPosition.position);
            enemy.SetTarget(_character.gameObject);
            
            return enemy;
        }

        public void DespawnEnemy(Enemy enemy)
        {
            _enemyPool.Release(enemy);
        }
    }
}