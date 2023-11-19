using System;

namespace ShootEmUp
{
    public interface IFireInput
    {
        event Action OnFireEvent;
    }
}