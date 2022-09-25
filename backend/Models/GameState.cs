namespace tower_battle.Models
{
    public class GameState
    {
        public PlayerState RightPlayerState { get; } = new PlayerState();
        public PlayerState LeftPlayerState { get; } = new PlayerState();
    }

    public class PlayerState
    {
        public IReadOnlyCollection<Unit> Units { get; } = new List<Unit>();
    }
}
