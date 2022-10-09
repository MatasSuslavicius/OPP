namespace tower_battle.Observer
{
    public abstract class Observer
    {
        private Subject subject;

        public abstract void UpdateUnits();
    }
}
