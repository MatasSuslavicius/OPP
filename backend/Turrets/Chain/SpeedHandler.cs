using tower_battle.Turrets.Decorator;

namespace tower_battle.Turrets.Chain
{
    public class SpeedHandler : Handler
    {
        public override void HandleRequest(string type, ITurret turret)
        {
            if (type == "speed")
            {
                turret.Speed += 10;
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, type);
            }
            else if (successor != null)
            {
                successor.HandleRequest(type, turret);
            }
        }
    }
}
