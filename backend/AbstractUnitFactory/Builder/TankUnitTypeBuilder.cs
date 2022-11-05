using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.AbstractUnitFactory.Units.Types;

namespace tower_battle.AbstractUnitFactory.Builder
{
    public class TankUnitTypeBuilder : IUnitTypeBuilder
    {
        public TankUnitTypeBuilder(UnitType unitType) : base(unitType) {}

        public override IUnitTypeBuilder SetCost(int cost)
        {
            unitType.Cost = (int)(1.5f * cost);
            return this;
        }
        public override IUnitTypeBuilder SetDamage(int damage)
        {
            unitType.Damage = damage;
            return this;
        }

        public override IUnitTypeBuilder SetHealth(int health)
        {
            unitType.InitialHealth = 1.5f * health;
            unitType.Health = 1.5f * health;
            return this;
        }

        public override IUnitTypeBuilder SetKillReward(int killReward)
        {
            unitType.KillReward = (int)(1.5f * killReward);
            return this;
        }
        public override IUnitTypeBuilder SetMovement(MovementStrategy strategy)
        {
            unitType.MovementStrategy = strategy;
            return this;
        }
    }
}
