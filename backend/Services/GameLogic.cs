using tower_battle.Models;

namespace tower_battle.Services
{
    public static class GameLogic
    {
        public static void Loop(this GameState state)
        {
            UpdateUnitPositions(state);
        }

        private static void UpdateUnitPositions(GameState state)
        {
            foreach(var leftPlayerUnit in state.LeftPlayerState.Units)
            {

            }

            foreach (var rightPlayerUnit in state.RightPlayerState.Units)
            {

            }
        }
    }
}
