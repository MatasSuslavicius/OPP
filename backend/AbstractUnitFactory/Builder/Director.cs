using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.AbstractUnitFactory.Units.Types;

namespace tower_battle.AbstractUnitFactory.Builder
{
    public class Director
    {
        public UnitType ConstructStoneAgeUnitType(IUnitTypeBuilder unitTypeBuilder, MovementStrategy strategy)
        {
            return unitTypeBuilder.SetMovement(strategy).SetDamage(2).SetHealth(100).SetKillReward(150).SetCost(100).Build();
        }
        public UnitType ConstructBronzeAgeUnitType(IUnitTypeBuilder unitTypeBuilder, MovementStrategy strategy)
        {
            return unitTypeBuilder.SetMovement(strategy).SetDamage(4).SetHealth(200).SetKillReward(400).SetCost(300).Build();
        }
    }
}
