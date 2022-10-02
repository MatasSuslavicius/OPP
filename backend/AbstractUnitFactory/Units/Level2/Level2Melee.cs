using tower_battle.AbstractUnitFactory.Units.Types;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units.Level2
{
    public class Level2Melee : Melee
    {
        public override float Speed { get; set; } = 6f;
        public override Vector2 Scale { get; set; } = new() { X = 0.5f, Y = 1.5f };
    }
}
