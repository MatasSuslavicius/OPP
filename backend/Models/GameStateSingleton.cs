using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Observer;
using tower_battle.Turrets;
using tower_battle.Turrets.Decorator;
using System.Linq;
using System.Text.Json.Serialization;
using tower_battle.State;

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

        public GameStateContext GameStateContext { get; set; } = new GameStateContext();
        public Dictionary<string, PlayerType> Connections { get; } = new ();
        public PlayerState RightPlayerState { get; } = new PlayerState();
        public PlayerState LeftPlayerState { get; } = new PlayerState();
        public UnitStructure UnitStructure { get; } = new UnitStructure();
    }

    public class PlayerState
    {
        public Army Army { get; set; } = new Army();
        public List<Unit> Units => Army.GetUnitArray();
        public ITurret Turret { get; set; }
        public double Money { get; set; } = 700;
        public double Experience { get; set; } = 0;
        public int Level { get; set; } = 1;
        public DateTime LastBuy { get; set; } = System.DateTime.Now;

        public void KillUnit(Unit unit)
        {
            Army.Children[(int)unit.UnitType.Legion].RemoveChild(unit);
            Money += unit.KillReward;
            Experience += unit.KillReward;
        }
    }
}
