using UnityEngine;

namespace ShootEmUp.Componets
{
    public abstract class MoveComponent: MonoBehaviour
    {
        public abstract void Move(Vector2 destination);
    }
}