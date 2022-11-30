using System.Text.Json.Serialization;
using tower_battle.AbstractUnitFactory.Units;

namespace tower_battle.Models
{
    public interface IArmyUnit : IEnumerable<IArmyUnit>
    {
        public abstract void AddChild(IArmyUnit armyUnit);
        public abstract void RemoveChild(IArmyUnit armyUnit);
    }
}
