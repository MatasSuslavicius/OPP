using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.AbstractUnitFactory.Units.Types;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Builder
{
    public abstract class IUnitTypeBuilder
    {
        protected UnitType unitType;
        public IUnitTypeBuilder(UnitType unitType)
        {
            this.unitType = unitType;
        }
        public abstract IUnitTypeBuilder SetHealth(int health);
        public abstract IUnitTypeBuilder SetDamage(float damage);
        public abstract IUnitTypeBuilder SetMovement(MovementStrategy strategy);
        public abstract IUnitTypeBuilder SetKillReward(int killReward);
        public abstract IUnitTypeBuilder SetCost(int cost);
        public abstract IUnitTypeBuilder SetScale(Vector2 scale);
        public UnitType Build()
        {
            return unitType;
        }
    }
}
