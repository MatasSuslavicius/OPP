using tower_battle.Turrets.Decorator;

namespace tower_battle.Turrets.Chain
{
    public class NotExistingHandler : Handler
    {
        public override void HandleRequest(string type, ITurret turret)
        {
            
            Console.WriteLine("Invalid upgrade type");
            if (successor != null)
            {
                successor.HandleRequest(type, turret);
            }
        }
    }
}
