using UnityEngine;

namespace ShootEmUp
{
    public static class MoveDirectionExtension
    {
        public static Vector2 ConvertToVector2(this MoveDirection direction)
        {
            return direction switch
            {
                MoveDirection.Left => new Vector2(-1, 0),
                MoveDirection.Right => new Vector2(1, 0),
                _ =>  Vector2.zero
            };
        }
    }
}