using tower_battle.Models;
using tower_battle.Turrets.Decorator;

namespace tower_battle.Turrets
{
    public class Turret : ITurret// <- Command reciever
    {
        public Turret ()
        {
        }

        public override void UpgradeTurret()
        {
        }
        public Turret CreateAction()
        {            
            this.Damage = 0.5f;
            this.Speed = 1;
            this.Range = 5;
            return this;
        }

    }
}
