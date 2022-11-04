using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy;

namespace tower_battle.AbstractUnitFactory.Builder
{
    public class Director
    {
        public Unit ConstructLevel1(IBuilder builder, MoveStrategy strategy)
        {
            return builder.AddMovement(strategy).AddDamage(2).AddHealth(100).AddKillReward(150).AddCost(100).Build();
        }
        public Unit ConstructLevel2(IBuilder builder, MoveStrategy strategy)
        {
            return builder.AddMovement(strategy).AddDamage(4).AddHealth(200).AddKillReward(400).AddCost(300).Build();
        }
    }
}
