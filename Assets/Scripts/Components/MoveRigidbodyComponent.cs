using System;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Componets
{
    public sealed class MoveRigidbodyComponent : MoveComponent
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float speed = 5.0f;
        private Vector2 _destination;
        
        public override void Move(Vector2 vector, float deltaTime)
        {
            var nextPosition = rigidbody2D.position + vector * (deltaTime * speed);
            rigidbody2D.MovePosition(nextPosition);
        }
        
    }
}