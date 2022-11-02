namespace tower_battle.Observer
{
    public abstract class Observer
    {
        private Subject subject;
        public bool isRightPlayer { get; set; }

        public abstract void UpdateUnits();
    }
}
