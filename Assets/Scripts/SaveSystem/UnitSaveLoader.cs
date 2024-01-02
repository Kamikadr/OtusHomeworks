using System.Linq;
using GameEngine;

namespace SaveSystem
{
    public class UnitSaveLoader: SaveLoader<UnitSnapshot[], UnitManager>
    {
        
        protected override UnitSnapshot[] ConvertToData(UnitManager service)
        {
            return service.GetAllUnits().Select(unit => unit.GetSnapshot()).ToArray();
        }

        protected override void SetupData(UnitManager service, UnitSnapshot[] data)
        {
            foreach (var unitSnapshot in data)
            {
                service.SetupUnit(unitSnapshot);
            }
        }
    }
    
}