namespace tower_battle.Observer
{
    public class LevelUpVisitor : IVisitor
    {
        public void Visit(UnitElement element)
        {
            element.leveledUp = true;
            Console.WriteLine("{0} leveled up",
                element.GetType().Name);
        }
    }
}
