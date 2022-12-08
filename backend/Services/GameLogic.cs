using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Models;
using tower_battle.Turrets;

namespace tower_battle.Services
{
    public static class GameLogic
    {
        public static void OnTurretUpgrade(PlayerState playerState)
        {
            var turretUnit = playerState.Army.FirstOrDefault<Unit>(u => u.UnitType.Legion == LegionType.Turret) as TurretToUnitAdapter;
            
            if (turretUnit != null)
            {
                turretUnit.UpdateTurretValues();
            }
        }

        public static void OnTurretSell(PlayerState playerState)
        {
            var turretUnit = playerState.Army.FirstOrDefault<Unit>(u => u.Type == "Turret") as TurretToUnitAdapter;
            
            if (turretUnit != null)
            {
                playerState.Army.RemoveChild(turretUnit);
            }
        }
    }
}
