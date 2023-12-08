using System;
using ShootEmUp.Componets;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : IFixedUpdateListener
    {
        private readonly MoveComponent _moveComponent;
        private readonly Transform _enemyTransform;
        private readonly float _moveThreshold;
        
        private Vector2 _destination;
        private bool _isReached;
        
        
        public event Action<bool> IsReachedChange;

        public EnemyMoveAgent(MoveComponent moveComponent,Transform enemyTransform, float moveThreshold = 0.25f)
        {
            _moveThreshold = moveThreshold;
            _moveComponent = moveComponent;
            _enemyTransform = enemyTransform;
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            _isReached = false;
            IsReachedChange?.Invoke(_isReached);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (_isReached)
            {
                return;
            }
            
            var vector = _destination - (Vector2) _enemyTransform.position;
            if (vector.sqrMagnitude <= _moveThreshold * _moveThreshold)
            {
                _isReached = true;
                IsReachedChange?.Invoke(_isReached);
                _moveComponent.Move(Vector2.zero);
                return;
            }

            var direction = vector.normalized;
            _moveComponent.Move(direction);
        }
    }
}