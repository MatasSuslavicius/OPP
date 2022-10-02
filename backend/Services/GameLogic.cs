using tower_battle.Models;

namespace tower_battle.Services
{
    public static class GameLogic
    {
        public static void Loop(this GameStateSingleton state)
        {
            UpdateUnitPositions(state);
        }

        private static void UpdateUnitPositions(GameStateSingleton state)
        {
            foreach(var leftPlayerUnit in state.LeftPlayerState.Units)
            {
                leftPlayerUnit.Position.X += leftPlayerUnit.Speed * GameManager.UPDATE_TIME;
            }

            foreach (var rightPlayerUnit in state.RightPlayerState.Units)
            {
                rightPlayerUnit.Position.X -= rightPlayerUnit.Speed * GameManager.UPDATE_TIME;
            }
        }
    }
}
