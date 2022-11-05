using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_battle.AbstractUnitFactory.Builder;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.Level1;
using tower_battle.AbstractUnitFactory.Units.MovementStrategies;

namespace tower_battle_tests.UnitsTests
{
    public class UnitMovementStrategyTests
    {

        [Fact]
        public void TestSlowMovement()
        {
            Unit unit = new Level1TankUnit();
            IUnitTypeBuilder unitTypeBuilder = new TankUnitTypeBuilder(unit);
            unit = unitTypeBuilder.AddMovement(new SlowMovementStrategy()).AddDamage(2).AddHealth(100).AddKillReward(50).AddCost(100).Build();

            Assert.Equal(1.5f, unit.Speed);
        }
        [Fact]
        public void TestNormalMovement()
        {
            Unit unit = new Level1NormalSoldierType();
            IUnitTypeBuilder unitTypeBuilder = new SoldierUnitTypeBuilder(unit);
            unit = unitTypeBuilder.AddMovement(new NormalMovementStrategy()).AddDamage(2).AddHealth(100).AddKillReward(50).AddCost(100).Build();

            Assert.Equal(3f, unit.Speed);
        }
        [Fact]
        public void TestFastMovement()
        {
            Unit unit = new Level1ScoutType();
            IUnitTypeBuilder unitTypeBuilder = new FastMeleeUnitTypeBuilder(unit);
            unit = unitTypeBuilder.AddMovement(new FastMovementStrategy()).AddDamage(2).AddHealth(100).AddKillReward(50).AddCost(100).Build();

            Assert.Equal(6f, unit.Speed);
        }

    }
}
