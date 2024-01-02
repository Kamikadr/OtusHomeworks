using System;
using System.Collections;
using System.Collections.Generic;
using GameEngine;
using UnityEngine;

namespace GameEngine
{
    [CreateAssetMenu(menuName = "UnitCatalog", fileName = "NewUnitCatalog")]
    public class UnitCatalog : ScriptableObject
    {
        [SerializeField] public UnitConfig[] unitConfigs;

        public Unit FindUnit(string unitId)
        {
            foreach (var unitConfig in unitConfigs)
            {
                if (unitConfig.unitId == unitId)
                {
                    return unitConfig.unitPrefab;
                }
            }

            throw new Exception($"No unit with {unitId} id");
        }
    }
}