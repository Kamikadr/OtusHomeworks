using System;
using Client.Components.Events;
using Client.Services;
using EcsExtension;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;

namespace Client {
    public sealed class EcsStartup : MonoBehaviour {
        private EcsWorld _world;
        private EcsWorld _eventWorld;
        private IEcsSystems _systems;
        private EntityManager _entityManager;


        public EcsWorld GetWorld(string worldName)
        {
            return _systems.GetWorld(worldName);
        }
        private void Awake()
        {
            _world = new EcsWorld ();
            _eventWorld = new EcsWorld();
            _systems = new EcsSystems (_world);
            _systems.AddWorld(_eventWorld, EcsWorlds.EventWorld);
            _entityManager = new EntityManager();

            _systems
                .Add(new DeathRequestSystem())
                
                
                .Add(new MovementSystem())
                .Add(new HpEmptySystem())
                
                
                //View
                .Add(new DeathAnimationListener())
                .Add(new TransformViewSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .DelHere<DeathEvent>();
        }

        void Start () 
        {
            _entityManager.Initialize(_world);
            _systems.Inject();
            _systems.Init();
        }

        void Update () {
            // process systems here.
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                // list of custom worlds will be cleared
                // during IEcsSystems.Destroy(). so, you
                // need to save it here if you need.
                _systems.Destroy ();
                _systems = null;
            }
            
            // cleanup custom worlds here.
            
            // cleanup default world.
            if (_world != null) {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}