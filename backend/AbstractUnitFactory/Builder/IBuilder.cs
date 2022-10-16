using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.Level2;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy.MoveTypes;
using tower_battle.Models;
namespace tower_battle.AbstractUnitFactory.Builder
{
    public abstract class IBuilder
    {
        protected Unit rawUnit;
        public IBuilder(Unit rawUnit)
        {
            this.rawUnit = rawUnit;
        }
        public abstract IBuilder AddHealth(double health);
        public abstract IBuilder AddDamage(double damage);
        public abstract IBuilder AddMovement(MoveStrategy strategy);
        public abstract IBuilder AddKillReward(double killReward);
        public Unit Build()
        {
            return rawUnit;
        }
    }
}
