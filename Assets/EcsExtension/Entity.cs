using System;
using System.Collections;
using System.Collections.Generic;
using EcsExtension;
using Leopotam.EcsLite;
using UnityEngine;

public class Entity : MonoBehaviour, IDisposable
{
    public int Id => _id;
    
    private int _id;
    private EcsWorld _world;

    [SerializeField] private EntityInstaller[] installers;
    public bool IsAlive()
    {
        return _world != null && _id != -1;
    }

    public void Initialize(EcsWorld world)
    {
        var newEntity = world.NewEntity();
        Initialize(newEntity, world);
    }
    public void Initialize(int id, EcsWorld world)
    {
        _world = world;
        _id = id;
        for (var i = 0; i < installers.Length; i++)
        {
            installers[i].Configure(this);
        }
    }
    

    public void Dispose()
    {
        for (var i = 0; i < installers.Length; i++)
        {
            installers[i].Dispose(this);
        }
        _world.DelEntity(_id);
        _world = null;
        _id = -1;
    }

    public void AddComponent<T>(T component) where T: struct
    {
        var pool = _world.GetPool<T>();
        pool.Add(_id)= component;
    }

    public void RemoveComponent<T>() where T : struct
    {
        var pool = _world.GetPool<T>();
        pool.Del(_id);
    }

    public ref T GetComponent<T>() where T : struct
    {
        var pool = _world.GetPool<T>();
        return ref pool.Get(_id);
    }
    public bool TryGetComponent<T>(ref T value) where T : struct
    {
        var pool = _world.GetPool<T>();
        if (pool.Has(_id))
        {
            value  = ref pool.Get(_id);
            return true;
        }

        value = default;
        return false;
    }
}
