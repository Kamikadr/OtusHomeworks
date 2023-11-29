using System;
using ShootEmUp.Componets;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour, IFixedUpdateListener
    {
        [SerializeField] private MoveComponent moveComponent;
        [SerializeField] private float moveThreshold = 0.25f;
        private Vector2 _destination;
        private bool _isReached;

        public event Action<bool> IsReachedChange;

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
            
            var vector = _destination - (Vector2) transform.position;
            if (vector.sqrMagnitude <= moveThreshold * moveThreshold)
            {
                _isReached = true;
                IsReachedChange?.Invoke(_isReached);
                moveComponent.Move(Vector2.zero);
                return;
            }

            var direction = vector.normalized;
            moveComponent.Move(direction);
        }
    }
}