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
        
        private readonly HashSet<GameObject> _activeEnemies = new();
        private bool _isNeedSpawningEnemies;
        
        public void SpawnEnemy()
        {
            if (_activeEnemies.Count < maxEnemyCount)
            {
                var enemy = enemySpawner.SpawnEnemy();
                if (_activeEnemies.Add(enemy.gameObject))
                {
                    enemy.Activate();
                    enemy.hitPointsComponent.HpIsEmptyEvent += OnDestroyed;
                }
            }
        }
        
        private void OnDestroyed(GameObject enemyGameObject)
        {
            if (_activeEnemies.Remove(enemyGameObject))
            {
                var enemy = enemyGameObject.GetComponent<Enemy>();
                DestroyEnemy(enemy);
            }
        }

        private void DestroyEnemy(Enemy enemy)
        {
            enemy.Deactivate();
            enemy.hitPointsComponent.HpIsEmptyEvent -= OnDestroyed;
            enemySpawner.DespawnEnemy(enemy);
        }


        public void OnFinish()
        {
            foreach (var enemyObject in _activeEnemies)
            {
                var enemy = enemyObject.GetComponent<Enemy>();
               DestroyEnemy(enemy);
            }
            _activeEnemies.Clear();
        }
        
        public void OnPause()
        {
            foreach (var enemyObject in _activeEnemies)
            {
                var enemy = enemyObject.GetComponent<Enemy>();
                enemy.Pause();
            }
        }

        public void OnResume()
        {
            foreach (var enemyObject in _activeEnemies)
            {
                var enemy = enemyObject.GetComponent<Enemy>();
                enemy.Resume();
            }
        }
    }
}