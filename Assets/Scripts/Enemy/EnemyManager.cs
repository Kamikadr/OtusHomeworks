using System.Collections;
using System.Collections.Generic;
using ShootEmUp.Bullets;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Enemies
{
    public sealed class EnemyManager : MonoBehaviour, IGameFinishListener, IGamePauseListener, IGameResumeListener
    {
        
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private int maxEnemyCount;
        
        private readonly HashSet<Enemy> _activeEnemies = new();
        private bool _isNeedSpawningEnemies;
        
        public void SpawnEnemy()
        {
            if (_activeEnemies.Count < maxEnemyCount)
            {
                var enemy = enemySpawner.SpawnEnemy();
                if (_activeEnemies.Add(enemy))
                {
                    enemy.Activate();
                    enemy.OnEnemyKilled += OnDestroyed;
                }
            }
        }
        
        private void OnDestroyed(Enemy enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                DestroyEnemy(enemy);
            }
        }

        private void DestroyEnemy(Enemy enemy)
        {
            enemy.Deactivate();
            enemy.OnEnemyKilled -= OnDestroyed;
            enemySpawner.DespawnEnemy(enemy);
        }


        public void OnFinish()
        {
            foreach (var enemy in _activeEnemies)
            {
                DestroyEnemy(enemy);
            }
            _activeEnemies.Clear();
        }
        
        public void OnPause()
        {
            foreach (var enemy in _activeEnemies)
            {
                enemy.Pause();
            }
        }

        public void OnResume()
        {
            foreach (var enemy in _activeEnemies)
            {
                enemy.Resume();
            }
        }
    }
}