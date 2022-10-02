﻿using tower_battle.AbstractUnitFactory.Units.Types;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units.Level1
{
    public class Level1Melee : Melee
    {
        public override float Speed { get; set; } = 3f;
        public override Vector2 Scale { get; set; } = new() { X = 0.5f, Y = 1f };
    }
}
