using tower_battle.Turrets.Decorator;

namespace tower_battle.Turrets.Proxy
{
    public class TurretProxy : ITurret
    {
        private Turret _turret;
        public TurretProxy()
        {
            Console.WriteLine("Creating Turret");
        }
        public override Turret CreateAction()
        {
            _turret = new Turret();
            return _turret.CreateAction();
        }

        public override void UpgradeTurret()//<------ ?
        {

        }
    }
}
