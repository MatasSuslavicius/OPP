using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units
{
    public abstract class Unit
    {
        public abstract float Speed { get; set; }
        public Vector2 Position { get; set; }
        public abstract Vector2 Scale { get; set; }
        public int Cost { get; set; }
        public double Health { get; set; }
        public double KillReward { get; set; } //TODO: Change type to GoldReward/XPReward ?
        public double Damage { get; set; }

    }
}
