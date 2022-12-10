namespace tower_battle.Observer
{
    public abstract class UnitElement
    {
        //private Subject subject;
        public bool isRightPlayer { get; set; }
        public bool leveledUp = false;
        public abstract float DamageMultiplier { get; set; }
        public abstract float Health { get; set; }

        public abstract void Accept(IVisitor visitor);
    }
}
