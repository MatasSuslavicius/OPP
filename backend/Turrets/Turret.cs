using tower_battle.Turrets.Decorator;
using tower_battle.Turrets.Memento;

namespace tower_battle.Turrets
{
    public class Turret : ITurret// <- Command reciever
    {
        public Turret ()
        {
        }
        public TurretCaretaker caretaker;
        public override void UpgradeTurret()
        {
        }
        public override Turret CreateAction()//proxy
        {
            this.Damage = 0.5f;
            this.Speed = 1;
            this.Range = 5;
            return this;
        }
        public void GetMemento(TurretMemento turretMemento)
        {
            this.Damage = turretMemento.Damage;
            this.Speed = turretMemento.Speed;
            this.Range = turretMemento.Range;
            this.Id = turretMemento.Id;
        }
        public TurretMemento CreateMemento()
        {
            return new TurretMemento { Damage = this.Damage, Speed = this.Speed, Range = this.Range, Id = this.Id };
        }
    }
}
