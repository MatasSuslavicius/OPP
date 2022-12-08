using System.Diagnostics;
using tower_battle.Models;

namespace tower_battle.State
{
    public class PausedGameState : IGameState
    {
        public void Loop(GameStateContext ctx)
        {
            var GameStateSave = GameStateSingleton.Instance;
            Debug.Assert(GameStateSave.Equals(GameStateSingleton.Instance));
        }
    }
}
