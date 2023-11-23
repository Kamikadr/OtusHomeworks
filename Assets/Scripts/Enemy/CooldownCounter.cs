using System;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp
{
    public class CooldownCounter : MonoBehaviour, IFixedUpdateListener
    {
        [SerializeField] private float countdown;
        private float _currentTime;
        private bool _needCount;

        public event Action CountIsDownEvent;

        public void SetActive(bool value)
        {
            _needCount = value;
        }

        public void Reset()
        {
            _currentTime = countdown;
        }

        public void OnFixedUpdate()
        {
            if (!_needCount)
            {
                return;
            }

            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0)
            {
                CountIsDownEvent?.Invoke();
                _currentTime += countdown;
            }
        }
    }
}