using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tower_battle.Turrets;

namespace tower_battle.Turrets.Memento
{
    public class TurretCaretaker
    {
        public Turret Originator { get; set; }
        public Stack<TurretMemento> Mementos { get; set; }
        public void SaveMemento()
        {
            Mementos.Push(Originator.CreateMemento());
        }
        public void RestoreMemento()
        {
            if (Mementos.Count == 0) return;
            TurretMemento turretMemento = Mementos.Pop();
            Originator.GetMemento(turretMemento);
        }
    }
}
