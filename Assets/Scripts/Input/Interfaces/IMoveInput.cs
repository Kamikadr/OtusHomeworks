using System;

namespace ShootEmUp.GameInput
{
    public interface IMoveInput
    {
        event Action<MoveDirection> OnMoveEvent;
    }
}