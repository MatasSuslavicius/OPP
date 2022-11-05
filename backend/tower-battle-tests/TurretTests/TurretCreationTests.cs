using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_battle.Turrets.Command;

namespace tower_battle_tests.TurretTests
{
    public class TurretCreationTests
    {
        private static TurretInvoker turretInvoker;

        [Fact]
        public void TurretCreateTest()
        {
            turretInvoker = new TurretInvoker();
            turretInvoker.Buy();
            Assert.Equal(0.5, turretInvoker.turret.Damage);
            Assert.Equal(1, turretInvoker.turret.Speed);
            Assert.Equal(5, turretInvoker.turret.Range);
        }
    }
}
