using tower_battle.AbstractUnitFactory.Units.Types;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units.Level2
{
    public class Level2FastMelee : FastMelee
    {
        public override float Speed { get; set; }
        public override Vector2 Scale { get; set; }
    }
}
