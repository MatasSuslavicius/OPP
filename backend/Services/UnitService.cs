using tower_battle.AbstractUnitFactory;
using tower_battle.AbstractUnitFactory.Factories;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Models;

namespace tower_battle.Services
{
    public class UnitService
    {
        public UnitService() { }
        public bool Create()
        {
            ICreator ctr = new UnitFactory();
            var levelFactory = ctr.GetUnitFactory(GameStateSingleton.Instance.GameLevel);
            GameStateSingleton.Instance.RightPlayerState.Units.Add(levelFactory.CreateMelee(false));
            GameStateSingleton.Instance.LeftPlayerState.Units.Add(levelFactory.CreateMelee(true));
            return true;
        }

        public bool LevelUp()
        {
            if (GameStateSingleton.Instance.GameLevel >= 2)
            {
                GameStateSingleton.Instance.GameLevel = 2; // Resetting to current max game level.
                return false;
            }
            else
            {
                GameStateSingleton.Instance.GameLevel++;
                return true;
            }
        }

        public void ClearUnits()
        {
            GameStateSingleton.Instance.RightPlayerState.Units.Clear();
            GameStateSingleton.Instance.LeftPlayerState.Units.Clear();
        }

        public void ResetLevel()
        {
            GameStateSingleton.Instance.GameLevel = 1;
        }
    }
}
