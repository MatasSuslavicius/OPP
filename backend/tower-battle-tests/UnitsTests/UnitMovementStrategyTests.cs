using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_battle.AbstractUnitFactory.Builder;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.Level1;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy.MoveTypes;

namespace tower_battle_tests.UnitsTests
{
    public class UnitMovementStrategyTests
    {

        [Fact]
        public void TestSlowMovement()
        {
            Unit unit = new Level1SlowMelee();
            IBuilder builder = new SlowMeleeBuilder(unit);
            unit = builder.AddMovement(new Slow()).AddDamage(2).AddHealth(100).AddKillReward(50).AddCost(100).Build();

            Assert.Equal(1.5f, unit.Speed);
        }
        [Fact]
        public void TestNormalMovement()
        {
            Unit unit = new Level1NormalMelee();
            IBuilder builder = new NormalMeleeBuilder(unit);
            unit = builder.AddMovement(new Normal()).AddDamage(2).AddHealth(100).AddKillReward(50).AddCost(100).Build();

            Assert.Equal(3f, unit.Speed);
        }
        [Fact]
        public void TestFastMovement()
        {
            Unit unit = new Level1FastMelee();
            IBuilder builder = new FastMeleeBuilder(unit);
            unit = builder.AddMovement(new Fast()).AddDamage(2).AddHealth(100).AddKillReward(50).AddCost(100).Build();

            Assert.Equal(6f, unit.Speed);
        }

    }
}
