using System.Collections;
using System.Collections.Generic;
using ShootEmUp.Bullets;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Enemies
{
    public sealed class EnemyManager : MonoBehaviour
    {
        
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private int maxEnemyCount;
        
        private readonly HashSet<GameObject> _activeEnemies = new();
        private bool _isNeedSpawningEnemies;
        
        public void SpawnEnemy()
        {
            if (_activeEnemies.Count < maxEnemyCount)
            {
                var enemy = enemySpawner.SpawnEnemy();
                if (_activeEnemies.Add(enemy.gameObject))
                {
                    enemy.hitPointsComponent.HpIsEmptyEvent += OnDestroyed;
                }
            }
        }
        
        private void OnDestroyed(GameObject enemyGameObject)
        {
            if (_activeEnemies.Remove(enemyGameObject))
            {
                var enemy = enemyGameObject.GetComponent<Enemy>();
                enemy.hitPointsComponent.HpIsEmptyEvent -= OnDestroyed;
                enemySpawner.UnspawnEnemy(enemy);
            }
        }


    }
}