﻿using tower_battle.AbstractUnitFactory;
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
                if(/*GameStateSingleton.Instance.RightPlayerState.Experience >= 400 &&*/ GameStateSingleton.Instance.RightPlayerState.Level < 2)
                {
                    GameStateSingleton.Instance.RightPlayerState.Level++;
                    GameStateSingleton.Instance.UnitManager.LevelUp(isRightPlayer);
                    return true;
                }

                return false;
            }
            else
            {
                if (/*GameStateSingleton.Instance.LeftPlayerState.Experience >= 400 && */ GameStateSingleton.Instance.LeftPlayerState.Level < 2)
                {
                    GameStateSingleton.Instance.LeftPlayerState.Level++;
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
            GameStateSingleton.Instance.LeftPlayerState.Level = 1;
            GameStateSingleton.Instance.RightPlayerState.Level = 1;
        }
    }
}
