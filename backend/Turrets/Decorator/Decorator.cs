namespace tower_battle.Turrets.Decorator
{
    public abstract class Decorator : ITurret
    {
        protected ITurret turret;

        protected Decorator(ITurret turret)
        {
            this.turret = turret;
        }
        public override void UpgradeTurret()
        {
            turret.UpgradeTurret();
        }
    }
}
