using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.AbstractUnitFactory.Units.Types;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Builder
{
    public class SoldierUnitTypeBuilder : IUnitTypeBuilder
    {
        public SoldierUnitTypeBuilder(UnitType unitType) : base(unitType) {}

        public override IUnitTypeBuilder SetCost(int cost)
        {
            unitType.Cost = cost;
            return this;
        }

        public override IUnitTypeBuilder SetScale(Vector2 scale)
        {
            unitType.Scale.X = scale.X;
            unitType.Scale.Y = scale.Y;
            return this;
        }

        public override IUnitTypeBuilder SetDamage(float damage)
        {
            unitType.Damage = damage;
            return this;
        }

        public override IUnitTypeBuilder SetHealth(int health)
        {
            unitType.InitialHealth = health;
            unitType.Health = health;
            return this;
        }

        public override IUnitTypeBuilder SetKillReward(int killReward)
        {
            unitType.KillReward = killReward;
            return this;
        }

        public override IUnitTypeBuilder SetMovement(MovementStrategy strategy)
        {
            unitType.MovementStrategy = strategy;
            return this;
        }
    }
}
