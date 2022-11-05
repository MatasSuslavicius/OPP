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
        private static StoneAgeUnitFactory _stoneAgeFactory = new StoneAgeUnitFactory(PlayerType.Left);
        private static BronzeAgeUnitFactory _bronzeAgeFactory = new BronzeAgeUnitFactory(PlayerType.Left);
        private static Unit unit;

        //builder.AddMovement(strategy).AddDamage(2).AddHealth(100).AddKillReward(50).AddCost(100).Build();
        //builder.AddMovement(strategy).AddDamage(4).AddHealth(200).AddKillReward(100).AddCost(300).Build();

        [Fact]
        public void CreateLevel1NormalMeleeUnitTest()
        {
            unit = _stoneAgeFactory.CreateSoldier();

            Assert.Equal(2.2, unit.Damage, 5);
            Assert.Equal(100, unit.Health, 5);
            Assert.Equal(195, unit.KillReward, 5);
            Assert.Equal(130, unit.Cost);
        }
        [Fact]
        public void CreateLevel1SlowMeleeUnitTest()
        {
            unit = _stoneAgeFactory.CreateTank();

            Assert.Equal(2.2, unit.Damage, 5);
            Assert.Equal(150, unit.Health, 5);
            Assert.Equal(292.5, unit.KillReward, 5);
            Assert.Equal(195, unit.Cost);
        }
        [Fact]
        public void CreateLevel1FastMeleeUnitTest()
        {
            unit = _stoneAgeFactory.CreateScout();

            Assert.Equal(2.2, unit.Damage, 5);
            Assert.Equal(75, unit.Health, 5);
            Assert.Equal(195, unit.KillReward, 5);
            Assert.Equal(260, unit.Cost);
        }
        [Fact]
        public void CreateLevel2NormalMeleeUnitTest()
        {
            unit = _bronzeAgeFactory.CreateSoldier();

            Assert.Equal(4.8, unit.Damage, 5);
            Assert.Equal(200, unit.Health, 5);
            Assert.Equal(600, unit.KillReward, 5);
            Assert.Equal(420, unit.Cost);
        }
        [Fact]
        public void CreateLevel2SlowMeleeUnitTest()
        {
            unit = _bronzeAgeFactory.CreateTank();

            Assert.Equal(4.8, unit.Damage, 5);
            Assert.Equal(300, unit.Health, 5);
            Assert.Equal(900, unit.KillReward, 5);
            Assert.Equal(630, unit.Cost);
        }
        [Fact]
        public void CreateLevel2FastMeleeUnitTest()
        {
            unit = _bronzeAgeFactory.CreateScout();

            Assert.Equal(4.8, unit.Damage, 5);
            Assert.Equal(150, unit.Health, 5);
            Assert.Equal(600, unit.KillReward, 5);
            Assert.Equal(840, unit.Cost);
        }
    }
}
