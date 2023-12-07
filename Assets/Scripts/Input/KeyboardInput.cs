using System;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.GameInput
{
    public sealed class KeyboardInput : IFireInput, IMoveInput, IUpdateListener
    {
        public event Action OnFireEvent;
        public event Action<Vector2> OnMoveEvent;

        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireEvent?.Invoke();
            }

            OnMoveEvent?.Invoke(GetDestination());
        }

        private Vector2 GetDestination()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                return Vector2.left;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                return Vector2.right;
            }

            return Vector2.zero;
        }
        
    }
}