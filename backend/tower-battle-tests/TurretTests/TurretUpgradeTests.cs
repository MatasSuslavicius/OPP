using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_battle.Turrets;
using tower_battle.Turrets.Decorator;

namespace tower_battle_tests.TurretTests
{
    public class TurretUpgradeTests
    {
        private static Turret turret;
        
        [Fact]
        public void TurretDamageUpgradeTest()
        {
            turret = new Turret();
            turret = turret.CreateAction();
            DamageUpgrade damageUpgrade = new DamageUpgrade(turret);
            damageUpgrade.UpgradeTurret();
            turret = damageUpgrade.Get() as Turret;

            Assert.Equal(30, turret.Damage);
            Assert.Equal(1, turret.Speed);
            Assert.Equal(50, turret.Range);
        }
        [Fact]
        public void TurretRangeUpgradeTest()
        {
            turret = new Turret();
            turret = turret.CreateAction();
            RangeUpgrade rangeUpgrade = new RangeUpgrade(turret);
            rangeUpgrade.UpgradeTurret();
            turret = rangeUpgrade.Get() as Turret;

            Assert.Equal(20, turret.Damage);
            Assert.Equal(1, turret.Speed);
            Assert.Equal(60, turret.Range);
        }
        [Fact]
        public void TurretSpeedUpgradeTest()
        {
            turret = new Turret();
            turret = turret.CreateAction();
            SpeedUpgrade speedUpgrade = new SpeedUpgrade(turret);
            speedUpgrade.UpgradeTurret();
            turret = speedUpgrade.Get() as Turret;

            Assert.Equal(20, turret.Damage);
            Assert.Equal(11, turret.Speed);
            Assert.Equal(50, turret.Range);
        }
        [Fact]
        public void TurretDoubleDamageUpgradeTest()
        {
            turret = new Turret();
            turret = turret.CreateAction();
            DamageUpgrade damageUpgrade = new DamageUpgrade(turret);
            damageUpgrade.UpgradeTurret();
            damageUpgrade.UpgradeTurret();
            turret = damageUpgrade.Get() as Turret;

            Assert.Equal(40, turret.Damage);
            Assert.Equal(1, turret.Speed);
            Assert.Equal(50, turret.Range);
        }
    }
}
