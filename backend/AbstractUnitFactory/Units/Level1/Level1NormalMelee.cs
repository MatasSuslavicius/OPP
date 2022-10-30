using tower_battle.AbstractUnitFactory.Units.Types;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units.Level1
{
    public class Level1NormalMelee : Melee
    {
        public override Vector2 Scale { get; set; } = new() { X = 1f, Y = 1f };
    }
}
