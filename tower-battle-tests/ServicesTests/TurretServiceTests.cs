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
            Assert.Equal(20, GameStateSingleton.Instance.LeftPlayerState.Turret.Damage);
            Assert.Equal(1,GameStateSingleton.Instance.LeftPlayerState.Turret.Speed);
            Assert.Equal(50, GameStateSingleton.Instance.LeftPlayerState.Turret.Range);
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
        }
        [Fact]
        public void BuyTurretUpgradeTurretDoesNotExistTest()
        {
            GameStateSingleton.Instance.RightPlayerState.Turret = null;
            GameStateSingleton.Instance.RightPlayerState.Money = 200;

            Assert.False(_turretService.Upgrade("damage", PlayerType.Right));
        }
        [Fact]
        public void BuyTurretUpgradeAndEnoughMoneyAndTurretExistsTest()
        {
            GameStateSingleton.Instance.RightPlayerState.Turret = null;
            GameStateSingleton.Instance.RightPlayerState.Money = 500;
            _turretService.Create(PlayerType.Right);
            GameStateSingleton.Instance.RightPlayerState.Money = 200;
            Assert.True(_turretService.Upgrade("damage", PlayerType.Right));
            Assert.Equal(30,GameStateSingleton.Instance.RightPlayerState.Turret.Damage);
            Assert.Equal(1, GameStateSingleton.Instance.RightPlayerState.Turret.Speed);
            Assert.Equal(50, GameStateSingleton.Instance.RightPlayerState.Turret.Range);
        }
    }
}
