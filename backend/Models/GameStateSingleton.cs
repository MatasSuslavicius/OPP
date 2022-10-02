using tower_battle.AbstractUnitFactory.Units;

namespace tower_battle.Models
{
    public sealed class GameStateSingleton
    {
        private static readonly GameStateSingleton instance = new GameStateSingleton();

        private GameStateSingleton() { }

        public static GameStateSingleton Instance
        {
            get { return instance; }
        }

        public PlayerState RightPlayerState { get; } = new PlayerState();
        public PlayerState LeftPlayerState { get; } = new PlayerState();
        public int GameLevel { get; set; } = 1;
    }

    public class PlayerState
    {
        public ICollection<Unit> Units { get; } = new List<Unit>();
    }
}
