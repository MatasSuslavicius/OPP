using Newtonsoft.Json;
using System.Collections;
using System.Text.Json.Serialization;
using tower_battle.AbstractUnitFactory.Units;

namespace tower_battle.Models
{
    [JsonObject]
    public class Legion : IArmyUnit
    {
        public string Name { get; set; }
        public int UnitCount { get; }
        private List<IArmyUnit> Children = new();

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
