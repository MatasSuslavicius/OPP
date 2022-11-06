namespace tower_battle.AbstractUnitFactory.Units
{
    public class UnitHealth
    {
        public double Health { get; set; }
        public UnitHealth(double health)
        {
            this.Health = health;
        }
        public UnitHealth CopyShallow()
        {
            return (UnitHealth)this.MemberwiseClone();
        }

    }
}
