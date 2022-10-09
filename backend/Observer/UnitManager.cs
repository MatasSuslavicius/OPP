namespace tower_battle.Observer
{
    public class UnitManager : Subject
    {
        public UnitManager() : base() { }
        public override void LevelUp()
        {
            foreach (var obs in Observers)
            {
                obs.UpdateUnits();
            }
        }

        public override void Subscribe(Observer observer)
        {
            this.Observers.Add(observer);
        }

        public override void Unsubscribe(Observer observer)
        {
            this.Observers.Remove(observer);
        }
    }
}
