namespace tower_battle.Models
{
    public class LobbyInfo
    {
        public bool FirstPlayerOnline => GameStateSingleton.Instance.Connections.ContainsValue(PlayerType.Left);

        public bool SecondPlayerOnline => GameStateSingleton.Instance.Connections.ContainsValue(PlayerType.Right);
        public int VisitorCount => GameStateSingleton.Instance.Connections.Count(x => x.Value == PlayerType.Spectator);

        private static readonly LobbyInfo instance = new();

        private LobbyInfo() { }

        public static LobbyInfo Instance => instance;
    }
}
