using ShootEmUp.Bullets;
using ShootEmUp.Characters;
using ShootEmUp.Common;
using ShootEmUp.Game;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private Pool<Enemy> enemyPool;
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private GameManager gameManager;

        public Enemy SpawnEnemy()
        {
            var enemy = enemyPool.Get();
            var spawnPosition = enemyPositions.RandomSpawnPosition();
            var attackPosition = enemyPositions.RandomAttackPosition();
            
            enemy.SetParent(worldTransform);
            enemy.SetPosition(spawnPosition.position);
            enemy.SetDestination(attackPosition.position);
            enemy.SetTarget(character.gameObject);

            gameManager.AddListeners(enemy.gameObject);
            return enemy;
        }

        public void DespawnEnemy(Enemy enemy)
        {
            enemyPool.Release(enemy);
            gameManager.RemoveListeners(enemy.gameObject);
        }
    }
}