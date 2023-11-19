using System;

namespace ShootEmUp
{
    public interface IMoveInput
    {
        event Action<MoveDirection> OnMoveEvent;
    }
}