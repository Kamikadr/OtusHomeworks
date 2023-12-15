using System;
using ShootEmUp.Game;
using ShootEmUp.Game.Interfaces.GameCycle;

namespace ShootEmUp.Enemies
{
    public class CooldownCounter: IUpdateListener, IDisposable
    {
        private readonly GameContext _gameContext;
        private readonly float _countdown;
        private float _currentTime;
        private bool _needCount;

        public CooldownCounter(GameContext gameContext ,float enemyCooldown)
        {
            gameContext.AddListener(this);
            _gameContext = gameContext;
            _countdown = enemyCooldown;
        }
        public event Action CountIsDownEvent;

        public void SetActive(bool value)
        {
            _needCount = value;
        }
        public void OnUpdate(float deltaTime)
        {
            if (!_needCount)
            {
                return;
            }
            
            _currentTime -= deltaTime;
            
            if (_currentTime <= 0)
            {
                CountIsDownEvent?.Invoke();
                _currentTime += _countdown;
            }
        }

        public void Dispose()
        {
            _gameContext.RemoveListener(this);
        }
    }
}