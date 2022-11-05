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
    public class TurretServiceTests
    {
        private readonly TurretService _turretService = new TurretService();

        [Fact]
        public void BuyTurretAndNotEnoughMoneyTest()
        {
            GameStateSingleton.Instance.LeftPlayerState.Money = 400;

            Assert.False(_turretService.Create(PlayerType.Left));

            GameStateSingleton.Instance.RightPlayerState.Money = 400;

            Assert.False(_turretService.Create(PlayerType.Right));
        }
        [Fact]
        public void BuyTurretAndTurretAlreadyExistsTest()
        {
            TurretInvoker turretInvoker = new TurretInvoker();
            turretInvoker.Buy();
            GameStateSingleton.Instance.RightPlayerState.Turret = turretInvoker.turret;
            GameStateSingleton.Instance.RightPlayerState.Money = 500;

            Assert.False(_turretService.Create(PlayerType.Right));
        }
        [Fact]
        public void BuyTurretAndEnoughMoneyTest()
        {
            GameStateSingleton.Instance.LeftPlayerState.Money = 500;

            Assert.True(_turretService.Create(PlayerType.Left));
            Assert.Equal(0.5, GameStateSingleton.Instance.LeftPlayerState.Turret.Damage);
            Assert.Equal(1,GameStateSingleton.Instance.LeftPlayerState.Turret.Speed);
            Assert.Equal(5, GameStateSingleton.Instance.LeftPlayerState.Turret.Range);
            Assert.Equal(-9, GameStateSingleton.Instance.LeftPlayerState.Turret.Position.X);
            Assert.Equal(0, GameStateSingleton.Instance.LeftPlayerState.Turret.Position.Y);
        }
        [Fact]
        public void SellTurretAndTurretDoesNotExistsTest()
        {
            GameStateSingleton.Instance.RightPlayerState.Turret = null;

            Assert.False(_turretService.Sell(PlayerType.Left));
        }
        [Fact]
        public void SellTurretAndTurretExistsTest()
        {
            GameStateSingleton.Instance.RightPlayerState.Money = 500;
            Assert.True(_turretService.Create(PlayerType.Right));
            Assert.True(_turretService.Sell(PlayerType.Right));

            GameStateSingleton.Instance.LeftPlayerState.Money = 500;
            Assert.True(_turretService.Create(PlayerType.Left));
            Assert.True(_turretService.Sell(PlayerType.Left));
        }
        [Fact]
        public void MoneyGainOnSellTest()
        {
            GameStateSingleton.Instance.RightPlayerState.Money = 500;
            Assert.True(_turretService.Create(PlayerType.Right));
            Assert.True(_turretService.Sell(PlayerType.Right));
            Assert.Equal(450, GameStateSingleton.Instance.RightPlayerState.Money);
        }

        [Fact]
        public void BuyTurretUpgradeAndNotEnoughMoneyTest()
        {
            GameStateSingleton.Instance.RightPlayerState.Money = 500;
            _turretService.Create(PlayerType.Right);
            GameStateSingleton.Instance.RightPlayerState.Money = 100;

            Assert.False(_turretService.Upgrade("damage", PlayerType.Right));

            GameStateSingleton.Instance.LeftPlayerState.Money = 500;
            _turretService.Create(PlayerType.Left);
            GameStateSingleton.Instance.LeftPlayerState.Money = 100;

            Assert.False(_turretService.Upgrade("damage", PlayerType.Left));
        }
        [Fact]
        public void BuyTurretUpgradeTurretDoesNotExistTest()
        {
            GameStateSingleton.Instance.RightPlayerState.Turret = null;
            GameStateSingleton.Instance.RightPlayerState.Money = 200;

            Assert.False(_turretService.Upgrade("damage", PlayerType.Right));

            GameStateSingleton.Instance.LeftPlayerState.Turret = null;
            GameStateSingleton.Instance.LeftPlayerState.Money = 200;

            Assert.False(_turretService.Upgrade("damage", PlayerType.Left));
        }
        [Fact]
        public void BuyTurretUpgradeAndEnoughMoneyAndTurretExistsTest()
        {
            GameStateSingleton.Instance.RightPlayerState.Turret = null;
            GameStateSingleton.Instance.RightPlayerState.Money = 500;
            _turretService.Create(PlayerType.Right);
            GameStateSingleton.Instance.RightPlayerState.Money = 600;
            Assert.True(_turretService.Upgrade("damage", PlayerType.Right));
            Assert.True(_turretService.Upgrade("range", PlayerType.Right));
            Assert.True(_turretService.Upgrade("speed", PlayerType.Right));
            Assert.Equal(10.5, GameStateSingleton.Instance.RightPlayerState.Turret.Damage);
            Assert.Equal(11, GameStateSingleton.Instance.RightPlayerState.Turret.Speed);
            Assert.Equal(15, GameStateSingleton.Instance.RightPlayerState.Turret.Range);


            GameStateSingleton.Instance.LeftPlayerState.Turret = null;
            GameStateSingleton.Instance.LeftPlayerState.Money = 500;
            _turretService.Create(PlayerType.Left);
            GameStateSingleton.Instance.LeftPlayerState.Money = 600;
            Assert.True(_turretService.Upgrade("damage", PlayerType.Left));
            Assert.Equal(10.5, GameStateSingleton.Instance.LeftPlayerState.Turret.Damage);
            Assert.Equal(1, GameStateSingleton.Instance.LeftPlayerState.Turret.Speed);
            Assert.Equal(5, GameStateSingleton.Instance.LeftPlayerState.Turret.Range);
        }
        [Fact]
        public void BuyTurretUpgradeWithNotExistingTypeTest()
        {
            GameStateSingleton.Instance.RightPlayerState.Turret = null;
            GameStateSingleton.Instance.RightPlayerState.Money = 500;
            _turretService.Create(PlayerType.Right);
            GameStateSingleton.Instance.RightPlayerState.Money = 600;
            Action act = () => _turretService.Upgrade("notExisting", PlayerType.Right);
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Invalid upgrade type", exception.Message);
        }
        [Fact]
        public void ClearTurretTest()
        {
            GameStateSingleton.Instance.RightPlayerState.Turret = null;
            GameStateSingleton.Instance.RightPlayerState.Money = 500;
            _turretService.Create(PlayerType.Right);
            _turretService.ClearTower();
            Assert.Equal(null, GameStateSingleton.Instance.RightPlayerState.Turret);
            Assert.Equal(null, GameStateSingleton.Instance.LeftPlayerState.Turret);
        }
    }
}
