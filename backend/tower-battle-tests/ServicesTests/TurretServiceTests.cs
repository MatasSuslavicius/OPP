using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_battle.Models;
using tower_battle.Services;
using tower_battle.Turrets.Command;

namespace tower_battle_tests.ServicesTests
{
    public class TurretServiceTests : IDisposable
    {
        private readonly TurretService _turretService;
        private GameStateSingleton singleton;

        //setup
        public TurretServiceTests()
        {
            _turretService = new TurretService();
            singleton = GameStateSingleton.Instance;
        }
        // teardown
        public void Dispose()
        {
            singleton = null;
        }

        [Fact]
        public void BuyTurretAndNotEnoughMoneyTest()
        {
            singleton.LeftPlayerState.Money = 400;

            Assert.False(_turretService.Create(PlayerType.Left));

            singleton.RightPlayerState.Money = 400;

            Assert.False(_turretService.Create(PlayerType.Right));
        }
        [Fact]
        public void BuyTurretAndTurretAlreadyExistsTest()
        {
            TurretInvoker turretInvoker = new TurretInvoker();
            turretInvoker.Buy();
            singleton.RightPlayerState.Turret = turretInvoker.turret;
            singleton.RightPlayerState.Money = 500;

            Assert.False(_turretService.Create(PlayerType.Right));
        }
        [Fact]
        public void BuyTurretAndEnoughMoneyTest()
        {
            _turretService.ClearTower();
            singleton.LeftPlayerState.Money = 500;
            Assert.True(_turretService.Create(PlayerType.Left));
            Assert.Equal(0.5, singleton.LeftPlayerState.Turret.Damage);
            Assert.Equal(1, singleton.LeftPlayerState.Turret.Speed);
            Assert.Equal(5, singleton.LeftPlayerState.Turret.Range);
            Assert.Equal(-9, singleton.LeftPlayerState.Turret.Position.X);
            Assert.Equal(0, singleton.LeftPlayerState.Turret.Position.Y);
        }
        [Fact]
        public void SellTurretAndTurretDoesNotExistsTest()
        {
            singleton.RightPlayerState.Turret = null;

            Assert.False(_turretService.Sell(PlayerType.Left));
        }
        [Fact]
        public void SellTurretAndTurretExistsTest()
        {
            _turretService.ClearTower();
            singleton.RightPlayerState.Money = 500;
            Assert.True(_turretService.Create(PlayerType.Right));
            Assert.True(_turretService.Sell(PlayerType.Right));

            singleton.LeftPlayerState.Money = 500;
            Assert.True(_turretService.Create(PlayerType.Left));
            Assert.True(_turretService.Sell(PlayerType.Left));
        }
        [Fact]
        public void MoneyGainOnSellTest()
        {
            _turretService.ClearTower();
            singleton.RightPlayerState.Money = 500;
            Assert.True(_turretService.Create(PlayerType.Right));
            Assert.True(_turretService.Sell(PlayerType.Right));
            Assert.Equal(450, singleton.RightPlayerState.Money);
        }

        [Theory]
        [InlineData("damage")]
        [InlineData("range")]
        [InlineData("speed")]
        public void BuyTurretUpgradeAndNotEnoughMoneyTest(string upgradeType)
        {
            singleton.RightPlayerState.Money = 500;
            _turretService.Create(PlayerType.Right);
            singleton.RightPlayerState.Money = 0;
            Assert.False(_turretService.Upgrade(upgradeType, PlayerType.Right));

            singleton.LeftPlayerState.Money = 500;
            _turretService.Create(PlayerType.Left);
            singleton.LeftPlayerState.Money = 0;
            Assert.False(_turretService.Upgrade(upgradeType, PlayerType.Left));
        }
        [Theory]
        [InlineData("damage")]
        [InlineData("range")]
        [InlineData("speed")]
        public void BuyTurretUpgradeTurretDoesNotExistTest(string upgradeType)
        {
            singleton.RightPlayerState.Turret = null;
            singleton.RightPlayerState.Money = 200;

            Assert.False(_turretService.Upgrade(upgradeType, PlayerType.Right));

            singleton.LeftPlayerState.Turret = null;
            singleton.LeftPlayerState.Money = 200;

            Assert.False(_turretService.Upgrade(upgradeType, PlayerType.Left));
        }
        [Fact]
        public void BuyTurretUpgradeAndEnoughMoneyAndTurretExistsTest()
        {
            singleton.RightPlayerState.Turret = null;
            singleton.RightPlayerState.Money = 500;
            _turretService.Create(PlayerType.Right);
            singleton.RightPlayerState.Money = 600;
            Assert.True(_turretService.Upgrade("damage", PlayerType.Right));
            Assert.True(_turretService.Upgrade("range", PlayerType.Right));
            Assert.True(_turretService.Upgrade("speed", PlayerType.Right));
            Assert.Equal(1, singleton.RightPlayerState.Turret.Damage);
            Assert.Equal(11, singleton.RightPlayerState.Turret.Speed);
            Assert.Equal(10, singleton.RightPlayerState.Turret.Range);


            singleton.LeftPlayerState.Turret = null;
            singleton.LeftPlayerState.Money = 500;
            _turretService.Create(PlayerType.Left);
            singleton.LeftPlayerState.Money = 600;
            Assert.True(_turretService.Upgrade("damage", PlayerType.Left));
            Assert.Equal(1, singleton.LeftPlayerState.Turret.Damage);
            Assert.Equal(1, singleton.LeftPlayerState.Turret.Speed);
            Assert.Equal(5, singleton.LeftPlayerState.Turret.Range);
        }
        [Fact]
        public void BuyTurretUpgradeWithNotExistingTypeTest()
        {
            singleton.RightPlayerState.Turret = null;
            singleton.RightPlayerState.Money = 500;
            _turretService.Create(PlayerType.Right);
            singleton.RightPlayerState.Money = 600;
            Action act = () => _turretService.Upgrade("notExisting", PlayerType.Right);
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Invalid upgrade type", exception.Message);
        }
        [Fact]
        public void ClearTurretTest()
        {
            singleton.RightPlayerState.Turret = null;
            singleton.RightPlayerState.Money = 500;
            _turretService.Create(PlayerType.Right);
            _turretService.ClearTower();
            Assert.Equal(null, singleton.RightPlayerState.Turret);
            Assert.Equal(null, singleton.LeftPlayerState.Turret);
        }

        
    }
}
