using tower_battle.AbstractUnitFactory;
using tower_battle.AbstractUnitFactory.Factories;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Models;
using tower_battle.Turrets;
using tower_battle.Turrets.Command;
using tower_battle.Turrets.Decorator;

namespace tower_battle.Services
{
    public class TurretService
    {
        private int turretPrice = 500;
        private int upgradePrice = 200;
        public bool Create(PlayerType playerType)
        {
            if ((playerType == PlayerType.Left && GameStateSingleton.Instance.LeftPlayerState.Turret != null) ||
                (playerType == PlayerType.Right && GameStateSingleton.Instance.RightPlayerState.Turret != null))
            {
                return false;
            }
           
            TurretInvoker turretInvoker = new TurretInvoker();
            turretInvoker.Buy();
            

            if (playerType == PlayerType.Left)
            {
                if (GameStateSingleton.Instance.LeftPlayerState.Money < turretPrice)
                {
                    return false;
                }
                turretInvoker.turret.Position = new Vector2 { X = -9, Y = 0 };
                GameStateSingleton.Instance.LeftPlayerState.Turret = turretInvoker.turret;
                GameStateSingleton.Instance.LeftPlayerState.Money -= turretPrice; 
                GameStateSingleton.Instance.LeftPlayerState.Units.Add(new TurretToUnitAdapter(turretInvoker.turret));
            }
            else if (playerType == PlayerType.Right)
            {
                if (GameStateSingleton.Instance.RightPlayerState.Money < turretPrice)
                {
                    return false;
                }
                turretInvoker.turret.Position = new Vector2 { X = 8, Y = 0 };
                GameStateSingleton.Instance.RightPlayerState.Turret = turretInvoker.turret;
                GameStateSingleton.Instance.RightPlayerState.Money -= turretPrice;
                GameStateSingleton.Instance.RightPlayerState.Units.Add(new TurretToUnitAdapter(turretInvoker.turret));
            }

            return true;
        }
        public bool Sell(PlayerType playerType)
        {
            if ((playerType == PlayerType.Left && GameStateSingleton.Instance.LeftPlayerState.Turret == null) ||
                (playerType == PlayerType.Right && GameStateSingleton.Instance.RightPlayerState.Turret == null))
            {
                return false;
            }
            TurretInvoker turretInvoker = new TurretInvoker();
            
            if (playerType == PlayerType.Left)
            {
                turretInvoker.turret = GameStateSingleton.Instance.LeftPlayerState.Turret as Turret;
                turretInvoker.UndoBuy();
                GameStateSingleton.Instance.LeftPlayerState.Turret = turretInvoker.turret;
                GameStateSingleton.Instance.LeftPlayerState.Money += turretPrice*0.9;
                GameLogic.OnTurretSell(GameStateSingleton.Instance.LeftPlayerState);
            }
            else if (playerType == PlayerType.Right)
            {
                turretInvoker.turret = GameStateSingleton.Instance.RightPlayerState.Turret as Turret;
                turretInvoker.UndoBuy();
                GameStateSingleton.Instance.RightPlayerState.Turret = turretInvoker.turret;
                GameStateSingleton.Instance.RightPlayerState.Money += turretPrice*0.9;
                GameLogic.OnTurretSell(GameStateSingleton.Instance.RightPlayerState);
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
                if (GameStateSingleton.Instance.LeftPlayerState.Money < upgradePrice)
                {
                    return false;
                }
                GameStateSingleton.Instance.LeftPlayerState.Turret = turret;
                GameStateSingleton.Instance.LeftPlayerState.Money -= upgradePrice;
                GameLogic.OnTurretUpgrade(GameStateSingleton.Instance.LeftPlayerState);
            }
            else if (playerType == PlayerType.Right)
            {
                if (GameStateSingleton.Instance.RightPlayerState.Money < upgradePrice)
                {
                    return false;
                }
                GameStateSingleton.Instance.RightPlayerState.Turret = turret;
                GameStateSingleton.Instance.RightPlayerState.Money -= upgradePrice;
                GameLogic.OnTurretUpgrade(GameStateSingleton.Instance.RightPlayerState);
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
