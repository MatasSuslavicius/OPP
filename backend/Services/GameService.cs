using tower_battle.Models;

namespace tower_battle.Services;

public class GameService
{
    public PlayerType GetPlayerType(string connectionId) => GameStateSingleton.Instance.Connections[connectionId];

    public void SetPlayerType(string connectionId, PlayerType type)
    {
        var conn = GameStateSingleton.Instance.Connections;
        if (!conn.ContainsKey(connectionId))
        {
            conn.Add(connectionId, type);
        }
        else
        {
            conn[connectionId] = type;
        }
    }

    public PlayerType JoinGame(string connectionId)
    {
        var conn = GameStateSingleton.Instance.Connections;
        if (!conn.ContainsKey(connectionId))
        {
            if (!conn.ContainsValue(PlayerType.Left))
            {
                conn.Add(connectionId, PlayerType.Left);
                return PlayerType.Left;
            }

            if (!conn.ContainsValue(PlayerType.Right))
            {
                conn.Add(connectionId, PlayerType.Right);
                return PlayerType.Right;
            }

            conn.Add(connectionId, PlayerType.Spectator);
            return PlayerType.Spectator;
        }

        return conn[connectionId];
    }
}