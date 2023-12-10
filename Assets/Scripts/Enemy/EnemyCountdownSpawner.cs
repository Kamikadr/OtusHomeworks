using System;
using System.Threading;
using System.Threading.Tasks;
using ShootEmUp.Game.Interfaces.GameCycle;

namespace ShootEmUp.Enemies
{
    public class EnemyCountdownSpawner:
        IGameStartListener,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener,
        IDisposable
    {
        private readonly EnemyManager _enemyManager;
        private readonly float _countdownInSeconds;
        private bool _isNeedSpawningEnemies;
        private bool _isSpawning;
        private CancellationTokenSource _cancellationTokenSource;
        
        public EnemyCountdownSpawner(EnemyManager enemyManager, float spawnEnemyCooldown)
        {
            _enemyManager = enemyManager;
            _countdownInSeconds = spawnEnemyCooldown;
        }

        public void OnStart()
        {
            StartSpawning();
        }
        
        private void StartSpawning()
        {
            if (!_isSpawning)
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _isNeedSpawningEnemies = true;

                SpawnEnemiesAsync(_cancellationTokenSource.Token);
            }
        }
        
        private async Task SpawnEnemiesAsync(CancellationToken token = default)
        {
            _isSpawning = true;
            try
            {
                while (_isNeedSpawningEnemies)
                {
                    await Task.Delay(TimeSpan.FromSeconds(_countdownInSeconds), token);
                    _enemyManager.SpawnEnemy();
                }
            }
            finally
            {
                _isSpawning = false;
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }

        private void StopSpawning()
        {
            Cancel();
            _isNeedSpawningEnemies = false;
        }
        private void Cancel()
        {
            _cancellationTokenSource?.Cancel();
        }
        
        public void OnFinish()
        {
            StopSpawning();
        }

        public void OnPause()
        {
            StopSpawning();
        }

        public void OnResume()
        {
            StartSpawning();
        }

        public void Dispose()
        {
            Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }
    }
}