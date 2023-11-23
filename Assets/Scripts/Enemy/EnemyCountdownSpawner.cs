using System;
using System.Collections;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public class EnemyCountdownSpawner: MonoBehaviour, IGameStartListener, IGameFinishListener, IGamePauseListener, IGameResumeListener
    {
        [SerializeField] private EnemyManager enemyManager;
        [SerializeField] private float countdownInSeconds;
        private bool _isNeedSpawningEnemies;
        private Coroutine _currentCoroutine;


        private void StartSpawning()
        {
            _isNeedSpawningEnemies = true;
            _currentCoroutine = StartCoroutine(SpawnEnemiesCoroutine());
        }
        
        private IEnumerator SpawnEnemiesCoroutine()
        {
            while (_isNeedSpawningEnemies)
            {
                yield return new WaitForSeconds(countdownInSeconds);
                enemyManager.SpawnEnemy();
            }
        }

        private void StopSpawning()
        {
            StopCoroutine(_currentCoroutine);
            _isNeedSpawningEnemies = false;
        }

        public void OnStart()
        {
            StartSpawning();
        }

        public void Finish()
        {
            StopSpawning();
        }

        public void Pause()
        {
            StopSpawning();
        }

        public void Resume()
        {
            StartSpawning();
        }
    }
}