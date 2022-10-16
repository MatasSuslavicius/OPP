using tower_battle.Models;

namespace tower_battle.Services;

public class GameService
{
    public PlayerType GetPlayerType(string connectionId) => GameStateSingleton.Instance.Connections[connectionId];
}