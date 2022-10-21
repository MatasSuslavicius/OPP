using tower_battle.Models;
using tower_battle.Turrets.Decorator;

namespace tower_battle.Turrets
{
    public class Turret : ITurret
    {
        public Turret ()
        {
            this.Damage = 20;
            this.Speed = 1;
            this.Range = 50;
        }

        public override void UpgradeTurret()
        {
        }

    }
}
