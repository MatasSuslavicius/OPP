using tower_battle.Models;

namespace tower_battle.Turrets.Decorator
{
    public abstract class ITurret
    {
        public float Damage { get; set; }
        public float Speed { get; set; }
        public float Range { get; set; }
        public Vector2 Position { get; set; }
        public abstract void UpgradeTurret();
        
    }
}
