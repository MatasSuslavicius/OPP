using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_battle.AbstractUnitFactory;
using tower_battle.AbstractUnitFactory.Factories;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Models;

namespace tower_battle_tests.UnitsTests
{
    public class UnitCreationTests
    {
        
        private static ICreator factoryCreator = new UnitFactory();
        private static Level1UnitFactory level1Factory = new Level1UnitFactory(PlayerType.Left);
        private static Level2UnitFactory level2Factory = new Level2UnitFactory(PlayerType.Left);
        private static Unit unit;

        //builder.AddMovement(strategy).AddDamage(2).AddHealth(100).AddKillReward(50).AddCost(100).Build();
        //builder.AddMovement(strategy).AddDamage(4).AddHealth(200).AddKillReward(100).AddCost(300).Build();

        [Fact]
        public void CreateLevel1NormalMeleeUnitTest()
        {
            unit = level1Factory.CreateNormalMelee();

            Assert.Equal(2, unit.Damage);
            Assert.Equal(100, unit.Health);
            Assert.Equal(50, unit.KillReward);
            Assert.Equal(100, unit.Cost);
        }
        [Fact]
        public void CreateLevel1SlowMeleeUnitTest()
        {
            unit = level1Factory.CreateSlowMelee();

            Assert.Equal(2, unit.Damage);
            Assert.Equal(150, unit.Health);
            Assert.Equal(75, unit.KillReward);
            Assert.Equal(150, unit.Cost);
        }
        [Fact]
        public void CreateLevel1FastMeleeUnitTest()
        {
            unit = level1Factory.CreateFastMelee();

            Assert.Equal(2, unit.Damage);
            Assert.Equal(75, unit.Health);
            Assert.Equal(50, unit.KillReward);
            Assert.Equal(200, unit.Cost);
        }
        [Fact]
        public void CreateLevel2NormalMeleeUnitTest()
        {
            unit = level2Factory.CreateNormalMelee();

            Assert.Equal(4, unit.Damage);
            Assert.Equal(200, unit.Health);
            Assert.Equal(100, unit.KillReward);
            Assert.Equal(300, unit.Cost);
        }
        [Fact]
        public void CreateLevel2SlowMeleeUnitTest()
        {
            unit = level2Factory.CreateSlowMelee();

            Assert.Equal(4, unit.Damage);
            Assert.Equal(300, unit.Health);
            Assert.Equal(150, unit.KillReward);
            Assert.Equal(450, unit.Cost);
        }
        [Fact]
        public void CreateLevel2FastMeleeUnitTest()
        {
            unit = level2Factory.CreateFastMelee();

            Assert.Equal(4, unit.Damage);
            Assert.Equal(150, unit.Health);
            Assert.Equal(100, unit.KillReward);
            Assert.Equal(600, unit.Cost);
        }
    }
}
