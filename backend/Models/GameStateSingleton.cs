using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Observer;
using tower_battle.Turrets;
using tower_battle.Turrets.Decorator;

namespace tower_battle.Models
{
    public sealed class GameStateSingleton
    {
        private static readonly GameStateSingleton instance = new ();

        private GameStateSingleton() { }

        public static GameStateSingleton Instance
        {
            get { return instance; }
        }

        public Dictionary<string, PlayerType> Connections { get; } = new ();
        public PlayerState RightPlayerState { get; } = new PlayerState();
        public PlayerState LeftPlayerState { get; } = new PlayerState();
        public UnitManager UnitManager { get; } = new UnitManager ();
    }

    public class PlayerState
    {
        public UnitCollection Units { get; set; } = new ();
        public ITurret Turret { get; set; }
        public double Money { get; set; } = 700;
        public double Experience { get; set; } = 0;
        public int Level { get; set; } = 1;
        public DateTime LastBuy { get; set; } = System.DateTime.Now;

        public void KillUnit(Unit unit)
        {
            Units.Remove(unit);
            Money += unit.KillReward;
            Experience += unit.KillReward;
        }
    }
}
