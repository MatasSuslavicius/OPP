using tower_battle.Observer;

namespace tower_battle.Visitor
{
    public class HealthUpVisitor : IVisitor
    {
        public void Visit(UnitElement element)
        {
            element.Health += 20;
            Console.WriteLine("{0} units health increased to {1}",
                element.GetType().Name, element.Health);
        }
    }
}
