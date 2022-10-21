namespace tower_battle.Turrets.Decorator
{
    public class DamageUpgrade : Decorator
    {
        public DamageUpgrade(ITurret turret) : base(turret)
        {
        }
        public override void UpgradeTurret()
        {
            turret.Damage += 10;
        }
        public ITurret Get()
        {
            return turret;
        }
    }
}
