using UnityEngine;

namespace VContainer
{
    public abstract class Installer: MonoBehaviour
    {
        public abstract void Configure(IContainerBuilder builder);
    }
}