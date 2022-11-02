using tower_battle.AbstractUnitFactory;
using tower_battle.AbstractUnitFactory.Factories;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Models;
using tower_battle.Observer;

namespace tower_battle.Services
{
    public class UnitService
    {
        public UnitService() { }
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
            var levelFactory = factoryCreator.GetUnitFactory(playerType == PlayerType.Left ? GameStateSingleton.Instance.LeftPlayerLevel : GameStateSingleton.Instance.RightPlayerLevel, playerType);
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

            unit.isRightPlayer = playerType == PlayerType.Right;
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

            GameStateSingleton.Instance.UnitManager.Subscribe(unit);
            return true;
        }

        public bool LevelUp(bool isRightPlayer)
        {
            if (isRightPlayer)
            {
                if(GameStateSingleton.Instance.RightPlayerState.Experience >= 2000 && GameStateSingleton.Instance.RightPlayerLevel < 2)
                {
                    GameStateSingleton.Instance.RightPlayerLevel++;
                    GameStateSingleton.Instance.UnitManager.LevelUp(isRightPlayer);
                    return true;
                }

                return false;
            }
            else
            {
                if (GameStateSingleton.Instance.LeftPlayerState.Experience >= 2000 &&  GameStateSingleton.Instance.LeftPlayerLevel < 2)
                {
                    GameStateSingleton.Instance.LeftPlayerLevel++;
                    GameStateSingleton.Instance.UnitManager.LevelUp(isRightPlayer);
                    return true;
                }

                return false;
            }
        }

        public void ClearUnits()
        {
            GameStateSingleton.Instance.RightPlayerState.Units.Clear();
            GameStateSingleton.Instance.LeftPlayerState.Units.Clear();
        }

        public void ResetLevel()
        {
            GameStateSingleton.Instance.LeftPlayerLevel = 1;
            GameStateSingleton.Instance.RightPlayerLevel = 1;
        }
    }
}
