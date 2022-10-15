using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy;

namespace tower_battle.AbstractUnitFactory.Builder
{
    public class FastMeleeBuilder : IBuilder
    {
        public FastMeleeBuilder(Unit rawUnit) : base(rawUnit)
        {
            
        }
        public override IBuilder AddDamage(int damage)
        {
            rawUnit.Damage = damage;
            return this;
        }

        public override IBuilder AddHealth(int health)
        {
            rawUnit.Health = health;
            return this;
        }

        public override IBuilder AddKillReward(int killReward)
        {
            rawUnit.KillReward = killReward;
            return this;
        }
        public override IBuilder AddMovement(MoveStrategy strategy)
        {
            rawUnit.SetMoveStrategy(strategy, rawUnit);
            return this;
        }
    }
}
