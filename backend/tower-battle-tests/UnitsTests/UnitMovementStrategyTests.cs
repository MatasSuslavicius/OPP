using tower_battle.AbstractUnitFactory.Builder;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.AbstractUnitFactory.Units.Types;

namespace tower_battle_tests.UnitsTests
{
    public class UnitMovementStrategyTests
    {

        [Fact]
        public void TestSlowMovement()
        {
            IUnitTypeBuilder unitTypeBuilder = new TankUnitTypeBuilder(new TankType());
            var unitType = unitTypeBuilder.SetMovement(new SlowMovementStrategy()).SetDamage(2).SetHealth(100).SetKillReward(50).SetCost(100).Build();
            
            Unit unit = new StoneAgeUnit{ UnitType = unitType };

            Assert.Equal(1f, unit.UnitType.MovementStrategy.Speed, 5);
        }
        [Fact]
        public void TestNormalMovement()
        {
            IUnitTypeBuilder unitTypeBuilder = new SoldierUnitTypeBuilder(new SoldierType());
            var unitType = unitTypeBuilder.SetMovement(new NormalMovementStrategy()).SetDamage(2).SetHealth(100).SetKillReward(50).SetCost(100).Build();

            Unit unit = new StoneAgeUnit{ UnitType = unitType };
            
            Assert.Equal(2f, unit.UnitType.MovementStrategy.Speed, 5);
        }
        [Fact]
        public void TestFastMovement()
        {
            IUnitTypeBuilder unitTypeBuilder = new ScoutUnitTypeBuilder(new ScoutType());
            var unitType = unitTypeBuilder.SetMovement(new FastMovementStrategy()).SetDamage(2).SetHealth(100).SetKillReward(50).SetCost(100).Build();

            Unit unit = new StoneAgeUnit{ UnitType = unitType };
            
            Assert.Equal(2.5f, unit.UnitType.MovementStrategy.Speed, 5);
        }

    }
}
