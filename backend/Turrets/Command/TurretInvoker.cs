using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_battle.Turrets.Decorator;
using tower_battle.Turrets.Memento;

namespace tower_battle.Turrets.Command
{
    public class TurretInvoker
    {
        public ITurret turret;
        public TurretCaretaker caretaker;
        public TurretInvoker()
        {
            this.turret = new Turret();
        }
        public void Buy()
        {
            ICommand command = new BuyCommand((Turret)turret);
            turret = command.BuyTurret();
            // command.BuyTurret();
        }
        public void UndoBuy()
        {
            ICommand command = new BuyCommand((Turret)turret);
            turret = command.UndoTurret();
            //caretaker.RestoreMemento();
        }

    }
}
