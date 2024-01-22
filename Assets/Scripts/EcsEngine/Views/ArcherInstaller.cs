using System.Collections;
using System.Collections.Generic;
using Client.Components;
using EcsExtension;
using UnityEngine;

public class ArcherInstaller : EntityInstaller
{
    protected override void Configure(Entity entity)
    {
        entity.AddComponent(new Position {value = transform.position});
        entity.AddComponent(new MoveSpeed {value = 5f});
        entity.AddComponent(new MoveDirection {value = Vector3.forward});
        entity.AddComponent(new TransformView{value = transform});
    }

    protected override void Dispose(Entity entity)
    {
        
    }
}
