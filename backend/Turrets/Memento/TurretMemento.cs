using tower_battle.Models;
using tower_battle.Turrets.Memento;

namespace tower_battle.Turrets.Memento
{
    public class TurretMemento
    {
        public float Damage { get; set; }
        public float Speed { get; set; }
        public float Range { get; set; }
        public Vector2 Position { get; set; }
        public int Id { get; set; }
        // public abstract void UpgradeTurret();

    }
}
