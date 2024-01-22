using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

namespace EcsExtension
{
    public class EntityManager
    {
        private Dictionary<int, Entity> _entities;
        private EcsWorld _world;

        public void Initialize(EcsWorld world)
        {
            _entities = new Dictionary<int, Entity>();
            _world = world;

            var sceneEntities = Object.FindObjectsOfType<Entity>();
            for (var i = 0; i < sceneEntities.Length; i++)
            {
                sceneEntities[i].Initialize(_world);
                _entities.Add(sceneEntities[i].Id, sceneEntities[i]);
            }
        }

        public Entity Create(Entity prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            Entity entity = Object.Instantiate(prefab, position, rotation, parent);
            entity.Initialize(_world);
            _entities.Add(entity.Id, entity);
            return entity;
        }

        public void Destroy(int id)
        {
            if (_entities.Remove(id, out var value))
            {
                value.Dispose();
                Object.Destroy(value.gameObject);
            }
        }

        public Entity Get(int id)
        {
            return _entities[id];
        }
    }
}