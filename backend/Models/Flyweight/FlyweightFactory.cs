namespace tower_battle.Models.Flyweight
{
    public class FlyweightFactory
    {
        private static List<string>
            m_baseLegions = new List<string>() {"Soldier Legion", "Scout Legion", "Tank Legion"};

        private static Dictionary<string, LegionTypeDef> m_allLegions = new Dictionary<string, LegionTypeDef>();

        public static LegionTypeDef GetLegion(string legion)
        {
            if (m_allLegions.ContainsKey(legion)) 
                return m_allLegions[legion];

            var result = new LegionTypeDef {Name = legion};
            m_allLegions.Add(legion, result);
            return result;
        }

        public static List<IArmyUnit> GenerateBaseLegions() =>
            new List<IArmyUnit>(m_baseLegions.Select(x => new Legion(GetLegion(x))).ToList());
    }
}