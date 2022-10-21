﻿using tower_battle.AbstractUnitFactory;
using tower_battle.AbstractUnitFactory.Factories;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Models;
using tower_battle.Turrets;
using tower_battle.Turrets.Decorator;

namespace tower_battle.Services
{
    public class TurretService
    {
        public bool Create(PlayerType playerType)
        {
            if ((playerType == PlayerType.Left && GameStateSingleton.Instance.LeftPlayerState.Turret != null) ||
                (playerType == PlayerType.Right && GameStateSingleton.Instance.RightPlayerState.Turret != null))
            {
                return false;
            }
            Turret turret = new Turret();
            
            if (playerType == PlayerType.Left)
            {
                turret.Position = new Vector2 { X = -10, Y = 0 };
                GameStateSingleton.Instance.LeftPlayerState.Turret = turret;
                //System.Diagnostics.Debug.WriteLine(GameStateSingleton.Instance.LeftPlayerState.Turret.Damage);    //PACHEKINT AR SUSIKURIA
                //System.Diagnostics.Debug.WriteLine(GameStateSingleton.Instance.LeftPlayerState.Turret.Range);
                //System.Diagnostics.Debug.WriteLine(GameStateSingleton.Instance.LeftPlayerState.Turret.Speed);
            }
            else if (playerType == PlayerType.Right)
            {
                turret.Position = new Vector2 { X = 10, Y = 0 };
                GameStateSingleton.Instance.RightPlayerState.Turret = turret;
            }
            return true;
        }
        public bool Upgrade(string upgradeType, PlayerType playerType)
        {
            if ((playerType == PlayerType.Left && GameStateSingleton.Instance.LeftPlayerState.Turret == null) ||
                (playerType == PlayerType.Right && GameStateSingleton.Instance.RightPlayerState.Turret == null))
            {
                return false;
            }
            
            ITurret turret = null;
            if (playerType == PlayerType.Left)
            {
                turret = GameStateSingleton.Instance.LeftPlayerState.Turret;
            }
            else if (playerType == PlayerType.Right)
            {
                turret = GameStateSingleton.Instance.RightPlayerState.Turret;
            }
            switch (upgradeType)
            {
                case "damage":
                    DamageUpgrade damageUpgrade = new DamageUpgrade(turret);
                    damageUpgrade.UpgradeTurret();
                    turret = damageUpgrade.Get();
                    
                    break;
                case "range":
                    RangeUpgrade rangeUpgrade = new RangeUpgrade(turret);
                    rangeUpgrade.UpgradeTurret();
                    turret = rangeUpgrade.Get();
                    break;
                case "speed":
                    SpeedUpgrade speedUpgrade = new SpeedUpgrade(turret);
                    speedUpgrade.UpgradeTurret();
                    turret = speedUpgrade.Get();
                    break;
                default:
                    throw new Exception("Invalid upgrade type");
            }
            if (playerType == PlayerType.Left)
            {
                GameStateSingleton.Instance.LeftPlayerState.Turret = turret;
                //System.Diagnostics.Debug.WriteLine(GameStateSingleton.Instance.LeftPlayerState.Turret.Damage);   //PACHECKINIMUI UPGRADES
                //System.Diagnostics.Debug.WriteLine(GameStateSingleton.Instance.LeftPlayerState.Turret.Range);
                //System.Diagnostics.Debug.WriteLine(GameStateSingleton.Instance.LeftPlayerState.Turret.Speed);
                //System.Diagnostics.Debug.WriteLine(GameStateSingleton.Instance.LeftPlayerState.Turret.Position.X);
            }
            else if (playerType == PlayerType.Right)
            {
                GameStateSingleton.Instance.RightPlayerState.Turret = turret;
            }

            return true;
        }

        public void ClearTower()
        {
            GameStateSingleton.Instance.RightPlayerState.Turret = null;
            GameStateSingleton.Instance.LeftPlayerState.Turret = null;
        }
    }
}
