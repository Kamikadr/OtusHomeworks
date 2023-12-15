using System;
using ShootEmUp.Componets;
using ShootEmUp.Game;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent: IFixedUpdateListener, IDisposable
    {
        private readonly MoveComponent _moveComponent;
        private readonly Transform _enemyTransform;
        private readonly float _moveThreshold;
        
        private Vector2 _destination;
        private bool _isReached;
        private readonly GameContext _gameContext;


        public event Action<bool> IsReachedChange;

        public EnemyMoveAgent(GameContext gameContext, MoveComponent moveComponent,Transform enemyTransform, float moveThreshold = 0.25f)
        {
            _moveThreshold = moveThreshold;
            _moveComponent = moveComponent;
            _enemyTransform = enemyTransform;
            _gameContext = gameContext;
            _gameContext.AddListener(this);
            _moveThreshold = moveThreshold;
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
                _moveComponent.Move(Vector2.zero, deltaTime);
                return;
            }

            var direction = vector.normalized;
            _moveComponent.Move(direction, deltaTime);
        }

        public void Dispose()
        {
            _gameContext.RemoveListener(this);
        }
    }
}