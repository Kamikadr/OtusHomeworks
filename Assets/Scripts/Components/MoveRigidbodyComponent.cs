using UnityEngine;

namespace ShootEmUp.Componets
{
    public sealed class MoveRigidbodyComponent : MoveComponent
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float speed = 5.0f;
        private Vector2 _destination;
        
        public override void Move(Vector2 vector)
        {
            _destination = vector;
        }

        private void FixedUpdate()
        {
            var nextPosition = rigidbody2D.position + _destination * (speed * Time.deltaTime);
            rigidbody2D.MovePosition(nextPosition);
        }
    }
}