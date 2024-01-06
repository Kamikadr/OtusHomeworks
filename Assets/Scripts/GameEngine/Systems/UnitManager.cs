using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameEngine
{
    //Нельзя менять!
    [Serializable]
    public sealed class UnitManager
    {
        [SerializeField]
        private Transform container;

        [ShowInInspector, ReadOnly]
        private HashSet<Unit> sceneUnits = new();

        private readonly UnitFactory _unitFactory;

        public UnitManager(UnitFactory unitFactory, Transform container)
        {
            _unitFactory = unitFactory;
            this.container = container;
        }
        
        
        public void SetupUnits(IEnumerable<Unit> units)
        {
            sceneUnits = new HashSet<Unit>(units);
        }

        public void SetContainer(Transform container)
        {
            this.container = container;
        }

        [Button]
        public Unit SpawnUnit(Unit prefab, Vector3 position, Quaternion rotation)
        {
            var unit = Object.Instantiate(prefab, position, rotation, container);
            unit.SetUnitId(Guid.NewGuid());
            sceneUnits.Add(unit);
            return unit;
        }

        [Button]
        public void DestroyUnit(Unit unit)
        {
            if (sceneUnits.Remove(unit))
            {
                Object.Destroy(unit.gameObject);
            }
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            return sceneUnits;
        }

        public void SetupUnits(UnitSnapshot[] unitSnapshots)
        {
            DestroyAllUnits();
            foreach (var unitSnapshot in unitSnapshots)
            {
                var unit =_unitFactory.Create(unitSnapshot.Type, container);
                unit.SetSnapshot(unitSnapshot);
                sceneUnits.Add(unit);
            }
        }

        private void DestroyAllUnits()
        {
            foreach (var sceneUnit in sceneUnits)
            {
                Object.Destroy(sceneUnit.gameObject);
            }
            sceneUnits.Clear();
        }
    }
}