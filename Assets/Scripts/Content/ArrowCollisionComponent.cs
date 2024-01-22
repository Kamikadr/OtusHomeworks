using System;
using Client;
using Client.Components;
using UnityEngine;

namespace Content
{
    [RequireComponent(typeof(Entity))]
    public sealed class ArrowCollisionComponent : MonoBehaviour
    {
        private EcsStartup EcsStartup;
        private Entity _entity;

        private void Construct(EcsStartup ecsStartup)
        {
            EcsStartup = ecsStartup;
        }

        private void Awake()
        {
            _entity = GetComponent<Entity>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Entity>(out var target))
            {
                var world = EcsStartup.GetWorld(EcsWorlds.EventWorld);
                var entity = world.NewEntity();
                world.GetPool<CollisionEnterRequest>().Add(entity) = new CollisionEnterRequest();
                world.GetPool<SourceTarget>().Add(entity) = new SourceTarget { value = _entity.Id };
                world.GetPool<TargetEntity>().Add(entity) = new TargetEntity{ value = target.Id };
                world.GetPool<BulletTag>().Add(entity) = new BulletTag();
            }
        }
    }
}