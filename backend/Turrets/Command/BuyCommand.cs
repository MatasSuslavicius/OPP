using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_battle.Turrets.Decorator;

namespace tower_battle.Turrets.Command
{
    public class BuyCommand : ICommand
    {
        Turret turret;

        public BuyCommand(Turret turret)
        {
            this.turret = turret;
        }

        public Turret BuyTurret()
        {
            turret.CreateAction();
            return turret;
        }
        public Turret UndoTurret()
        {
            turret = null;
            return turret;
        }
    }
}
