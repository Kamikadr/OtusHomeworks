using UnityEngine;

namespace GameEngine
{
    public class UnitFactory
    {
        private readonly UnitCatalog _unitCatalog;
        public UnitFactory(UnitCatalog unitCatalog)
        {
            _unitCatalog = unitCatalog;
        }
        public Unit Create(string type, Transform container)
        {
            var prefab = _unitCatalog.FindUnit(type);
            return Object.Instantiate(prefab, container);
        }
    }
}