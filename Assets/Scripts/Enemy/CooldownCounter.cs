using System;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Enemies
{
    public class CooldownCounter : IFixedUpdateListener
    {
        private readonly float _countdown;
        private float _currentTime;
        private bool _needCount;

        public CooldownCounter(float enemyCooldown)
        {
            _countdown = enemyCooldown;
        }
        public event Action CountIsDownEvent;

        public void SetActive(bool value)
        {
            _needCount = value;
        }

        public void Reset()
        {
            _currentTime = _countdown;
        }

        public void OnFixedUpdate(float deltaTime)
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
    }
}