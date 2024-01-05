using UnityEngine;
using Zenject;

namespace GameEngine
{
    public abstract class ConstructTask : ScriptableObject
    {
        public abstract void Construct(DiContainer gameContext);
    }
}