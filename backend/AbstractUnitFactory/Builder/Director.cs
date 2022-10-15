using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy;

namespace tower_battle.AbstractUnitFactory.Builder
{
    public class Director
    {
        public Unit ConstructLevel1(IBuilder builder, MoveStrategy strategy)
        {
            return builder.AddMovement(strategy).AddDamage(25).AddHealth(100).AddKillReward(50).Build();
        }
        public Unit ConstructLevel2(IBuilder builder, MoveStrategy strategy)
        {
            return builder.AddMovement(strategy).AddDamage(50).AddHealth(200).AddKillReward(100).Build();
        }
    }
}
