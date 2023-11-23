using System;
using UnityEngine;

namespace ShootEmUp.GameInput
{
    public interface IMoveInput
    {
        event Action<Vector2> OnMoveEvent;
    }
}