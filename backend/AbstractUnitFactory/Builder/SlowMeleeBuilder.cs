using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy;

namespace tower_battle.AbstractUnitFactory.Builder
{
    public class SlowMeleeBuilder : IBuilder
    {
        public SlowMeleeBuilder(Unit rawUnit) : base(rawUnit)
        {
           
        }

        public override IBuilder AddDamage(double damage)
        {
            rawUnit.Damage = damage;
           return this;
        }

        public override IBuilder AddHealth(double health)
        {
            rawUnit.Health = new UnitHealth(1.5 * health);
            //rawUnit.Health.Health = 1.5*health;
            return this;
        }

        public override IBuilder AddKillReward(double killReward)
        {
            rawUnit.KillReward = 1.5*killReward;
            return this;
        }
        public override IBuilder AddMovement(MoveStrategy strategy)
        {
            rawUnit.SetMoveStrategy(strategy, rawUnit);
            return this;
        }
    }
}
