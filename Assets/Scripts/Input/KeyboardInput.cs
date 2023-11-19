using System;
using UnityEngine;

namespace ShootEmUp.GameInput
{
    public sealed class KeyboardInput : MonoBehaviour, IFireInput, IMoveInput
    {
        public event Action OnFireEvent;
        public event Action<MoveDirection> OnMoveEvent;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireEvent?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                OnMoveEvent?.Invoke(MoveDirection.Left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                OnMoveEvent?.Invoke(MoveDirection.Right);
            }
        }
    }
}