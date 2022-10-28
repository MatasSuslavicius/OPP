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
        public bool Create(string unitType, PlayerType playerType)
        {
            
            if (playerType == PlayerType.Left)
            {
                if ((System.DateTime.Now - GameStateSingleton.Instance.LeftPlayerState.LastBuy).TotalMilliseconds < 750) return false;
            }
            else if (playerType == PlayerType.Right)
            {
                if ((System.DateTime.Now - GameStateSingleton.Instance.RightPlayerState.LastBuy).TotalMilliseconds < 750) return false;
            }
            
            ICreator factoryCreator = new UnitFactory();
            var levelFactory = factoryCreator.GetUnitFactory(GameStateSingleton.Instance.GameLevel, playerType);
            Unit unit;
            switch (unitType)
            {
                case "normal":
                    unit = levelFactory.CreateNormalMelee();
                    break;
                case "fast":
                    unit = levelFactory.CreateFastMelee();
                    break;
                case "slow":
                    unit = levelFactory.CreateSlowMelee();
                    break;
                default:
                    throw new Exception("Invalid unit type");
            }

            if (playerType == PlayerType.Left)
            {
                if (GameStateSingleton.Instance.LeftPlayerState.Money < unit.Cost)
                {
                    return false;
                }
                GameStateSingleton.Instance.LeftPlayerState.Units.Add(unit);
                GameStateSingleton.Instance.LeftPlayerState.Money -= unit.Cost;
                GameStateSingleton.Instance.LeftPlayerState.LastBuy = System.DateTime.Now;
            }
            else if (playerType == PlayerType.Right)
            {
                if (GameStateSingleton.Instance.RightPlayerState.Money < unit.Cost)
                {
                    return false;
                }
                GameStateSingleton.Instance.RightPlayerState.Units.Add(unit);
                GameStateSingleton.Instance.RightPlayerState.Money -= unit.Cost;
                GameStateSingleton.Instance.RightPlayerState.LastBuy = System.DateTime.Now;
            }


            m_unitManager.Subscribe(unit);

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
