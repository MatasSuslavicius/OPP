using tower_battle.AbstractUnitFactory.Units.Types;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units.Level1
{
    public class Level1FastMelee : FastMelee
    {
        public override float Speed { get; set; }
        public override Vector2 Scale { get; set; }
    }
}
