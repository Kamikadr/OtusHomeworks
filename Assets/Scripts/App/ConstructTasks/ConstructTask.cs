using UnityEngine;
using Zenject;

namespace App.ConstructTasks
{
    public abstract class ConstructTask : ScriptableObject
    {
        public abstract void Construct(DiContainer gameContext);
    }
}