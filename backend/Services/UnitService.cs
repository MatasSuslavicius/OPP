using tower_battle.AbstractUnitFactory;
using tower_battle.AbstractUnitFactory.Factories;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Models;
using tower_battle.Observer;
using tower_battle.Visitor;

namespace tower_battle.Services
{
    public class UnitService
    {
        public UnitService() { }
        private int unitUpgradePrice = 200;
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
            var levelFactory = factoryCreator.GetUnitFactory(playerType == PlayerType.Left ? GameStateSingleton.Instance.LeftPlayerState.Level : GameStateSingleton.Instance.RightPlayerState.Level, playerType);
            Unit unit;
            switch (unitType)
            {
                case "Soldier":
                    unit = levelFactory.CreateSoldier();
                    break;
                case "Scout":
                    unit = levelFactory.CreateScout();
                    break;
                case "Tank":
                    unit = levelFactory.CreateTank();
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
                GameStateSingleton.Instance.LeftPlayerState.Army.Children[(int)unit.UnitType.Legion].AddChild(unit);
                GameStateSingleton.Instance.LeftPlayerState.Money -= unit.Cost;
                GameStateSingleton.Instance.LeftPlayerState.LastBuy = System.DateTime.Now;
            }
            else if (playerType == PlayerType.Right)
            {
                if (GameStateSingleton.Instance.RightPlayerState.Money < unit.Cost)
                {
                    return false;
                }
                GameStateSingleton.Instance.RightPlayerState.Army.Children[(int)unit.UnitType.Legion].AddChild(unit);
                GameStateSingleton.Instance.RightPlayerState.Money -= unit.Cost;
                GameStateSingleton.Instance.RightPlayerState.LastBuy = System.DateTime.Now;
            }

            GameStateSingleton.Instance.UnitStructure.Attach(unit);
            return true;
        }

        public bool LevelUp(bool isRightPlayer)
        {
            LevelUpVisitor levelUpVisitor = new LevelUpVisitor();
            if (isRightPlayer)
            {
                if(/*GameStateSingleton.Instance.RightPlayerState.Experience >= 400 &&*/ GameStateSingleton.Instance.RightPlayerState.Level < 2)
                {
                    GameStateSingleton.Instance.RightPlayerState.Level++;
                    GameStateSingleton.Instance.UnitStructure.Accept(levelUpVisitor, isRightPlayer);
                    return true;
                }

                return false;
            }
            else
            {
                if (/*GameStateSingleton.Instance.LeftPlayerState.Experience >= 400 && */ GameStateSingleton.Instance.LeftPlayerState.Level < 2)
                {
                    GameStateSingleton.Instance.LeftPlayerState.Level++;
                    GameStateSingleton.Instance.UnitStructure.Accept(levelUpVisitor, isRightPlayer);
                    return true;
                }

                return false;
            }
        }
        public bool Upgrade(string upgradeType, PlayerType playerType)
        {
            IVisitor visitor;
            if (upgradeType == "armyDamage")
            {
                visitor = new DamageUpVisitor();
            }
            else
            {
                visitor = new HealthUpVisitor();
            }
            
            if (playerType == PlayerType.Right)
            {
                if (GameStateSingleton.Instance.RightPlayerState.Money < unitUpgradePrice)
                {
                    return false;
                }
                GameStateSingleton.Instance.RightPlayerState.Money -= unitUpgradePrice;
                GameStateSingleton.Instance.UnitStructure.Accept(visitor, true);

                return true;
            }
            else
            {
                if (GameStateSingleton.Instance.LeftPlayerState.Money < unitUpgradePrice)
                {
                    return false;
                }
                GameStateSingleton.Instance.LeftPlayerState.Money -= unitUpgradePrice;
                GameStateSingleton.Instance.UnitStructure.Accept(visitor, false);
                return true;
            }
        }
        public void ResetLevel()
        {
            GameStateSingleton.Instance.LeftPlayerState.Level = 1;
            GameStateSingleton.Instance.RightPlayerState.Level = 1;
        }
    }
}
