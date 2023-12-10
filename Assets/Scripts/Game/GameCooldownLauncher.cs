using System;
using ShootEmUp.Common;

namespace ShootEmUp.Game
{
    public class GameCooldownLauncher: IDisposable
    {
        private readonly GameManager _gameManager;
        private readonly TimerSettings _timerSettings;
        private readonly float _cooldownTick;
        private readonly Timer _timer;
        private readonly StartCountdownObserver _countdownObserver;

        public GameCooldownLauncher(GameManager gameManager, TimerSettings timerSettings)
        {
            _gameManager = gameManager;
            _timerSettings = timerSettings;

            _timer = new Timer();
            _countdownObserver = new StartCountdownObserver(_timer);
        }
        
        public void StartGame()
        {
            _timer.OnTimerIsOver += RunGame;
            _timer.StartCountdownAsync(_timerSettings);
        }
        
        private void RunGame()
        {
            _timer.OnTimerIsOver -= RunGame;
            _gameManager.StartGame();
        }
        public void Dispose()
        {
            _timer.OnTimerIsOver -= RunGame;
            _countdownObserver.Dispose();
        }
    }
}