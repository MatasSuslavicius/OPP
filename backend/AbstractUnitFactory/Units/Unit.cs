using tower_battle.Models;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy;

namespace tower_battle.AbstractUnitFactory.Units
{
    public abstract class Unit : Observer.Observer
    {
        public float Speed { get; set; }
        public Vector2 Position { get; set; }
        public abstract Vector2 Scale { get; set; }  
        public int Cost { get; set; }
        public UnitHealth Health { get; set; }//just double jei "teorinis prototype" atmestas.
        public double KillReward { get; set; } //TODO: Change type to GoldReward/XPReward ?
        public double Damage { get; set; }
        public MoveStrategy MoveStrategy;
        public MoveStrategy GetMoveStrategy ()
        {
            return MoveStrategy;
        }
        public void SetMoveStrategy (MoveStrategy moveStrategy, Unit unit)
        {
            this.MoveStrategy = moveStrategy;
            this.MoveStrategy.MoveDifferently(unit);
        }
        public override void UpdateUnits()
        {
            this.Scale.X *= 3;
        }
        public Unit CopyShallow()
        {
            return (Unit)this.MemberwiseClone();
        }
        public Unit CopyDeep()
        {
            Unit copy = CopyShallow();
            copy.Health = this.Health.CopyShallow();
            return copy;
        }
    }
}
