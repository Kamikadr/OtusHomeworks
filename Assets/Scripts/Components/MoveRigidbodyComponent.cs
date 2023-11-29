using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Componets
{
    public sealed class MoveRigidbodyComponent : MoveComponent, IFixedUpdateListener
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float speed = 5.0f;
        private Vector2 _destination;
        
        public override void Move(Vector2 vector)
        {
            _destination = vector;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            var nextPosition = rigidbody2D.position + _destination * (speed * deltaTime);
            rigidbody2D.MovePosition(nextPosition);
        }
    }
}