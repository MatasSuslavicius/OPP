//namespace tower_battle.Observer
//{
//    public class UnitManager : Subject
//    {
//        public UnitManager() : base() { }
//        public override void LevelUp(bool isRightPlayer)
//        {
//            var list = Observers.Where(x => x.isRightPlayer == isRightPlayer);
//            foreach (var obs in list)
//            {
//                obs.UpdateUnits();
//            }
//        }

//        public override void Subscribe(Observer observer)
//        {
//            this.Observers.Add(observer);
//        }

//        public override void Unsubscribe(Observer observer)
//        {
//            this.Observers.Remove(observer);
//        }
//    }
//}
