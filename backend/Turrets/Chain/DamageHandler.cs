using tower_battle.Turrets.Decorator;

namespace tower_battle.Turrets.Chain
{
    public class DamageHandler : Handler
    {
        public override void HandleRequest(string type, ITurret turret)
        {
            if (type == "damage")
            {
                turret.Damage += 0.5f;
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
