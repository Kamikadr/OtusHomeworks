using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public class EnemyCountdownSpawner: MonoBehaviour
    {
        [SerializeField] private EnemyManager enemyManager;
        [SerializeField] private float countdownInSeconds;
        private bool _isNeedSpawningEnemies;

        private void Awake()
        {
            StartSpawning();
        }

        public void StartSpawning()
        {
            _isNeedSpawningEnemies = true;
            StartCoroutine(SpawnEnemiesCoroutine());
        }
        
        private IEnumerator SpawnEnemiesCoroutine()
        {
            while (_isNeedSpawningEnemies)
            {
                yield return new WaitForSeconds(countdownInSeconds);
                enemyManager.SpawnEnemy();
            }
        }
        public void StopSpawning()
        {
            _isNeedSpawningEnemies = false;
        }
    }
}