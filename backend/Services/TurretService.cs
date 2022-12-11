using tower_battle.AbstractUnitFactory;
using tower_battle.AbstractUnitFactory.Factories;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Models;
using tower_battle.Turrets;
using tower_battle.Turrets.Chain;
using tower_battle.Turrets.Command;
using tower_battle.Turrets.Decorator;
using tower_battle.Turrets.Memento;

namespace tower_battle.Services
{
    public class TurretService
    {
        private int turretPrice = 500;
        private int upgradePrice = 20;
        Handler handler1 = new DamageHandler();
        Handler handler2 = new RangeHandler();
        Handler handler3 = new SpeedHandler();
        Handler handler4 = new NotExistingHandler();
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
                turretInvoker.turret.Id = 0;
                GameStateSingleton.Instance.LeftPlayerState.Turret = turretInvoker.turret;
                GameStateSingleton.Instance.LeftPlayerState.Money -= turretPrice; 
                GameStateSingleton.Instance.LeftPlayerState.Army.AddChild(new TurretToUnitAdapter(turretInvoker.turret));
                GameStateSingleton.Instance.turretCaretakers[0] = (new TurretCaretaker { Mementos = new Stack<TurretMemento>(), Originator = (Turret)GameStateSingleton.Instance.LeftPlayerState.Turret });
                
            }
            else if (playerType == PlayerType.Right)
            {
                if (GameStateSingleton.Instance.RightPlayerState.Money < turretPrice)
                {
                    return false;
                }
                turretInvoker.turret.Position = new Vector2 { X = 8, Y = 0 };
                turretInvoker.turret.Id = 1;
                GameStateSingleton.Instance.RightPlayerState.Turret = turretInvoker.turret;
                GameStateSingleton.Instance.RightPlayerState.Money -= turretPrice;
                GameStateSingleton.Instance.RightPlayerState.Army.AddChild(new TurretToUnitAdapter(turretInvoker.turret));
                GameStateSingleton.Instance.turretCaretakers[1] = (new TurretCaretaker { Mementos = new Stack<TurretMemento>(), Originator = (Turret)GameStateSingleton.Instance.RightPlayerState.Turret });
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
            Console.WriteLine(GameStateSingleton.Instance.turretCaretakers[0]);
            if ((playerType == PlayerType.Left && GameStateSingleton.Instance.LeftPlayerState.Turret == null) ||
                (playerType == PlayerType.Right && GameStateSingleton.Instance.RightPlayerState.Turret == null))
            {
                return false;
            }
            handler1.SetNext(handler2);
            handler2.SetNext(handler3);
            handler3.SetNext(handler4);


            ITurret turret = null;
            if (playerType == PlayerType.Left)
            {
                turret = GameStateSingleton.Instance.LeftPlayerState.Turret;
                if (GameStateSingleton.Instance.LeftPlayerState.Money >= upgradePrice)
                {
                    GameStateSingleton.Instance.turretCaretakers[0].SaveMemento();
                }
            }
            else if (playerType == PlayerType.Right)
            {
                turret = GameStateSingleton.Instance.RightPlayerState.Turret;
                if (GameStateSingleton.Instance.RightPlayerState.Money >= upgradePrice)
                {
                    GameStateSingleton.Instance.turretCaretakers[1].SaveMemento();
                }
            }
            handler1.HandleRequest(upgradeType, turret);
            

            if (playerType == PlayerType.Left)
            {
                if (GameStateSingleton.Instance.LeftPlayerState.Money < upgradePrice)
                {
                    return false;
                }
                //GameStateSingleton.Instance.turretCaretakers[0].SaveMemento();
                GameStateSingleton.Instance.LeftPlayerState.Turret = turret;
                GameStateSingleton.Instance.LeftPlayerState.Money -= upgradePrice;
                GameLogic.OnTurretUpgrade(GameStateSingleton.Instance.LeftPlayerState);
                Console.WriteLine("upgrade 1:");
                Console.WriteLine(turret.Damage);
                Console.WriteLine(turret.Range);
            }
            else if (playerType == PlayerType.Right)
            {
                if (GameStateSingleton.Instance.RightPlayerState.Money < upgradePrice)
                {
                    return false;
                }
                //GameStateSingleton.Instance.turretCaretakers[1].SaveMemento();
                GameStateSingleton.Instance.RightPlayerState.Turret = turret;
                GameStateSingleton.Instance.RightPlayerState.Money -= upgradePrice;
                GameLogic.OnTurretUpgrade(GameStateSingleton.Instance.RightPlayerState);
                Console.WriteLine("upgrade 2:");
                Console.WriteLine( turret.Damage);
                Console.WriteLine( turret.Range);
            }

            return true;
        }
        public bool UndoUpgrade(PlayerType playerType)
        {
            if ((playerType == PlayerType.Left && GameStateSingleton.Instance.LeftPlayerState.Turret == null) ||
                (playerType == PlayerType.Right && GameStateSingleton.Instance.RightPlayerState.Turret == null))
            {
                return false;
            }
            TurretInvoker turretInvoker = new TurretInvoker();
            
            if (playerType == PlayerType.Left)
            {
                if (GameStateSingleton.Instance.turretCaretakers[0].Mementos.Count() == 0)
                {
                    return false;
                }
                ITurret turret = GameStateSingleton.Instance.LeftPlayerState.Turret;
                GameStateSingleton.Instance.turretCaretakers[0].RestoreMemento();
                GameStateSingleton.Instance.LeftPlayerState.Money += upgradePrice * 0.5 ;
                Console.WriteLine("undo 1:");
                Console.WriteLine(GameStateSingleton.Instance.LeftPlayerState.Turret.Damage);
                Console.WriteLine(GameStateSingleton.Instance.LeftPlayerState.Turret.Range);

            }
            else if (playerType == PlayerType.Right)
            {
                if (GameStateSingleton.Instance.turretCaretakers[1].Mementos.Count() == 0)
                {
                    return false;
                }
                ITurret turret = GameStateSingleton.Instance.LeftPlayerState.Turret;
                GameStateSingleton.Instance.turretCaretakers[1].RestoreMemento();
                GameStateSingleton.Instance.RightPlayerState.Money += upgradePrice * 0.5;
                Console.WriteLine("undo 2:");
                Console.WriteLine(GameStateSingleton.Instance.RightPlayerState.Turret.Damage);
                Console.WriteLine(GameStateSingleton.Instance.RightPlayerState.Turret.Range);
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
