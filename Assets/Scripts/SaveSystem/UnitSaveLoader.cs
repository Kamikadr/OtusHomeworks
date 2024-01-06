using System.Linq;
using DefaultNamespace;
using GameEngine;
using Zenject;

namespace SaveSystem
{
    public class UnitSaveLoader: SaveLoader<UnitSnapshot[], UnitManager>
    {
        [Inject]
        public UnitSaveLoader(GameFacade gameFacade) : base(gameFacade)
        {
        }
        protected override UnitSnapshot[] ConvertToData(UnitManager service)
        {
            return service.GetAllUnits().Select(unit => unit.GetSnapshot()).ToArray();
        }

        protected override void SetupData(UnitManager service, UnitSnapshot[] data)
        {
            service.SetupUnits(data);
        }
    }
    
}