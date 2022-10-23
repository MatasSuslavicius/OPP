using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_battle.Turrets.Decorator;

namespace tower_battle.Turrets.Command
{
    public interface ICommand
    {
        public Turret BuyTurret();
        public Turret UndoTurret();


    }
}
