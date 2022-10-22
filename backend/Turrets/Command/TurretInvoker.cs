using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_battle.Turrets.Decorator;

namespace tower_battle.Turrets.Command
{
    public class TurretInvoker
    {
        public Turret turret;
        public TurretInvoker()
        {
            this.turret = new Turret();
        }
        public void Buy()
        {
            ICommand command = new BuyCommand(turret);
            turret = command.BuyTurret();
        }
        public void UndoBuy()
        {
            ICommand command = new BuyCommand(turret);
            turret = command.UndoTurret();
        }

    }
}
