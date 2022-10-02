using tower_battle.AbstractUnitFactory;
using tower_battle.AbstractUnitFactory.Factories;
using tower_battle.Models;

namespace tower_battle.Services
{
    public class UnitService
    {
        public UnitService() { }
        public bool Create()
        {
            ICreator ctr = new UnitFactory();
            var levelFactory = ctr.GetUnitFactory(1);
            GameStateSingleton.Instance.RightPlayerState.Units.Add(levelFactory.CreateMelee(false));
            GameStateSingleton.Instance.LeftPlayerState.Units.Add(levelFactory.CreateMelee(true));
            return true;
        }
    }
}
