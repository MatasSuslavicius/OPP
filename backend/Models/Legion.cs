using Newtonsoft.Json;
using System.Collections;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Models.Flyweight;

namespace tower_battle.Models
{
    [JsonObject]
    public class Legion : IArmyUnit
    {
        public LegionTypeDef Type { get; set; }
        public int UnitCount 
        {
            get
            {
                return Children.Sum(c => c.UnitCount);
            }
        }
        private List<IArmyUnit> Children = new();

        public Legion(LegionTypeDef baseLegion)
        {
            this.Type = baseLegion;
        }

        public void AddChild(IArmyUnit armyUnit)
        {
            Children.Add(armyUnit);
        }

        public void RemoveChild(IArmyUnit armyUnit)
        {
            Children.Remove(armyUnit);
        }

        public IEnumerator<IArmyUnit> GetEnumerator()
        {
            foreach (var child in Children)
            {
                if (child is Unit)
                {
                    yield return child;
                }
                else
                {
                    foreach (var grandChild in child)
                    {
                        yield return grandChild;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
