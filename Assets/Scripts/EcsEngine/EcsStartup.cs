using System;
using Client.Services;
using EcsExtension;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        private EcsWorld _world;        
        private IEcsSystems _systems;
        private EntityManager _entityManager;

        private void Awake()
        {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            _entityManager = new EntityManager();

            _systems
                .Add(new MovementSystem())
                .Add(new TransformViewSystem())
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())

                // register additional worlds here, for example:
                // .AddWorld (new EcsWorld (), "events")
#if UNITY_EDITOR
                // add debug systems for custom worlds here, for example:
                // .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ("events"))
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
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