using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace GameEngine
{
    //Нельзя менять!
    [Serializable]
    public sealed class ResourceService
    {
        [ShowInInspector, ReadOnly]
        private Dictionary<string, Resource> _sceneResources = new();

        public void SetResources(IEnumerable<Resource> resources)
        {
            _sceneResources = resources.ToDictionary(it => it.ID);
        }

        public IEnumerable<Resource> GetResources()
        {
            return _sceneResources.Values;
        }

        public void SetupResource(IEnumerable<ResourceSnapshot> resourceSnapshots)
        {
            foreach (var resourceSnapshot in resourceSnapshots)
            {
                if (_sceneResources.TryGetValue(resourceSnapshot.Id, out var value))
                {
                    value.SetSnapshot(resourceSnapshot);
                }
                else
                {
                    throw new Exception($"No resource with {resourceSnapshot.Id} id on the scene");
                }
            }
        }
    }
}