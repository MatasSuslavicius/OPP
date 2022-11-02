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
    public class UnitServiceTests
    {
        private readonly UnitService _unitService = new UnitService();

        [Fact]
        public void BuyUnitAndTimeNowPassedTest()
        {
            GameStateSingleton.Instance.LeftPlayerState.Money = 500;

            Assert.False(_unitService.Create("normal", PlayerType.Left));

            GameStateSingleton.Instance.RightPlayerState.Money = 500;

            Assert.False(_unitService.Create("normal", PlayerType.Right));
        }
        [Fact]
        public void BuyUnitAndNotEnoughMoneyTest()
        {
            GameStateSingleton.Instance.LeftPlayerState.LastBuy = System.DateTime.Today;
            GameStateSingleton.Instance.LeftPlayerState.Money = 0;

            Assert.False(_unitService.Create("normal", PlayerType.Left));

            GameStateSingleton.Instance.RightPlayerState.LastBuy = System.DateTime.Today;
            GameStateSingleton.Instance.RightPlayerState.Money = 0;

            Assert.False(_unitService.Create("normal", PlayerType.Right));
        }
        [Fact]
        public void BuyUnitAndEnoughMoneyTest()
        {
            _unitService.ResetLevel();
            GameStateSingleton.Instance.LeftPlayerState.Money = 500;
            GameStateSingleton.Instance.LeftPlayerState.LastBuy = System.DateTime.Today;
            Assert.False(GameStateSingleton.Instance.LeftPlayerState.Units.Count > 0);
            Assert.True(_unitService.Create("normal", PlayerType.Left));
            Assert.True(GameStateSingleton.Instance.LeftPlayerState.Units.Count > 0);
            Assert.Equal(100, GameStateSingleton.Instance.LeftPlayerState.Units.First().Health);
        }
        [Fact]
        public void BuySlowUnitAndEnoughMoneyForRightPlayerTest()
        {
            _unitService.ClearUnits();
            _unitService.ResetLevel();
            GameStateSingleton.Instance.RightPlayerState.Money = 500;
            GameStateSingleton.Instance.RightPlayerState.LastBuy = System.DateTime.Today;
            Assert.False(GameStateSingleton.Instance.RightPlayerState.Units.Count > 0);
            Assert.True(_unitService.Create("slow", PlayerType.Right));
            Assert.True(GameStateSingleton.Instance.RightPlayerState.Units.Count > 0);
            Assert.Equal(150, GameStateSingleton.Instance.RightPlayerState.Units.First().Health);
        }
        [Fact]
        public void BuyFastUnitAndEnoughMoneyForRightPlayerTest()
        {
            _unitService.ClearUnits();
            _unitService.ResetLevel();
            GameStateSingleton.Instance.RightPlayerState.Money = 500;
            GameStateSingleton.Instance.RightPlayerState.LastBuy = System.DateTime.Today;
            Assert.False(GameStateSingleton.Instance.RightPlayerState.Units.Count > 0);
            Assert.True(_unitService.Create("fast", PlayerType.Right));
            Assert.True(GameStateSingleton.Instance.RightPlayerState.Units.Count > 0);
            Assert.Equal(75, GameStateSingleton.Instance.RightPlayerState.Units.First().Health);
        }
        [Fact]
        public void BuyNotExistingTypeUnitTest()
        {
            _unitService.ClearUnits();
            _unitService.ResetLevel();
            GameStateSingleton.Instance.RightPlayerState.Money = 500;
            GameStateSingleton.Instance.RightPlayerState.LastBuy = System.DateTime.Today;
            Assert.False(GameStateSingleton.Instance.RightPlayerState.Units.Count > 0);
            Action act = () => _unitService.Create("notExisting", PlayerType.Right);
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Invalid unit type", exception.Message);
            Assert.False(GameStateSingleton.Instance.RightPlayerState.Units.Count > 0);
        }
        [Fact]
        public void ClearUnitsTest()
        {
            _unitService.ClearUnits();
            Assert.Equal(0, GameStateSingleton.Instance.LeftPlayerState.Units.Count);
            Assert.Equal(0, GameStateSingleton.Instance.RightPlayerState.Units.Count);
        }
        [Fact]
        public void LevelUpTest()
        {

            Assert.Equal(1, GameStateSingleton.Instance.GameLevel);
            _unitService.LevelUp();
            Assert.Equal(2, GameStateSingleton.Instance.GameLevel);
        }
        [Fact]
        public void LevelUpIfAlreadyLevel2Test()
        {
            _unitService.LevelUp();
            Assert.Equal(2, GameStateSingleton.Instance.GameLevel);
            Assert.False(_unitService.LevelUp());
            Assert.Equal(2, GameStateSingleton.Instance.GameLevel);
        }
        [Fact]
        public void ResetLevelTest()
        {
            _unitService.ResetLevel();
            Assert.Equal(1, GameStateSingleton.Instance.GameLevel);
        }
    }
}
