using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.AbstractUnitFactory.Units.Types;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Builder
{
    public class ScoutUnitTypeBuilder : IUnitTypeBuilder
    {
        public ScoutUnitTypeBuilder(UnitType unitType) : base(unitType) {}

        public override IUnitTypeBuilder SetCost(int cost)
        {
            unitType.Cost = 2 * cost;
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
            unitType.InitialHealth = 0.75f * health;
            unitType.Health = 0.75f * health;
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
