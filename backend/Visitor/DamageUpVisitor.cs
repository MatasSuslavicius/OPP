using tower_battle.Observer;

namespace tower_battle.Visitor
{
    public class DamageUpVisitor : IVisitor
    {
        public void Visit(UnitElement element)
        {
            element.DamageMultiplier += 0.1f;
            Console.WriteLine("{0} units damage increased",
                element.GetType().Name);
        }
    }
}
