using System;
using UnityEngine;

namespace EcsExtension
{
    public abstract class EntityInstaller: MonoBehaviour
    {
        protected internal abstract void Configure(Entity entity);
        protected internal abstract void Dispose(Entity entity);
    }
}