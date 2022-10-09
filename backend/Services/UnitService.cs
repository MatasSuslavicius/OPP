using tower_battle.AbstractUnitFactory;
using tower_battle.AbstractUnitFactory.Factories;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Models;
using tower_battle.Observer;

namespace tower_battle.Services
{
    public class UnitService
    {
        private readonly UnitManager m_unitManager;

        public UnitService()
        {
            m_unitManager = new UnitManager();
        }
        public bool Create(string type)
        {
            ICreator ctr = new UnitFactory();
            var levelFactory = ctr.GetUnitFactory(GameStateSingleton.Instance.GameLevel);

            Unit right;
            Unit left;
            switch (type)
            {
                case "Normal":
                    right = levelFactory.CreateNormalMelee(false);
                    left = levelFactory.CreateNormalMelee(true);
                    break;
                case "Fast":
                    right = levelFactory.CreateFastMelee(false);
                    left = levelFactory.CreateFastMelee(true);
                    break;
                default:
                    right = levelFactory.CreateSlowMelee(false);
                    left = levelFactory.CreateSlowMelee(true);
                    break;
            }

            GameStateSingleton.Instance.RightPlayerState.Units.Add(right);
            GameStateSingleton.Instance.LeftPlayerState.Units.Add(left);

            m_unitManager.Subscribe(right);
            m_unitManager.Subscribe(left);

            return true;
        }

        public bool LevelUp()
        {
            m_unitManager.LevelUp();
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
