using tower_battle.AbstractUnitFactory.Units;
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
            foreach (var leftPlayerUnit in state.LeftPlayerState.Units)
            {
                if(!IsUnitColliding(leftPlayerUnit, state))
                {
                    leftPlayerUnit.Position.X += leftPlayerUnit.Speed * GameManager.UPDATE_TIME;
                }
                else
                {
                    state.RightPlayerState.Experience += leftPlayerUnit.KillReward;
                    state.RightPlayerState.Money += leftPlayerUnit.KillReward;
                }
            }

            foreach (var rightPlayerUnit in state.RightPlayerState.Units)
            {
                if (!IsUnitColliding(rightPlayerUnit, state))
                {
                    rightPlayerUnit.Position.X -= rightPlayerUnit.Speed * GameManager.UPDATE_TIME;
                }
                else
                {
                    state.LeftPlayerState.Experience += rightPlayerUnit.KillReward;
                    state.LeftPlayerState.Money += rightPlayerUnit.KillReward;
                }
            }
        } 

        private static bool IsUnitColliding(Unit unit, GameStateSingleton state)
        {
            foreach(Unit leftPlayerUnit in state.LeftPlayerState.Units)
            {
                if(unit != leftPlayerUnit && 
                    PositionRangesOverlap(
                        unit.Position.X + (unit.Scale.X / 2),
                        leftPlayerUnit.Position.X - (leftPlayerUnit.Scale.X / 2),
                        leftPlayerUnit.Position.X + (leftPlayerUnit.Scale.X / 2)))
                {
                    return true;
                }
            }

            foreach (Unit rightPlayerUnit in state.RightPlayerState.Units)
            {
                if (unit != rightPlayerUnit &&
                    PositionRangesOverlap(
                        unit.Position.X - (unit.Scale.X / 2),
                        rightPlayerUnit.Position.X - (rightPlayerUnit.Scale.X / 2),
                        rightPlayerUnit.Position.X + (rightPlayerUnit.Scale.X / 2)))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool PositionRangesOverlap(float aEnd, float bStart, float bEnd)
        {
            return aEnd > bStart && aEnd < bEnd;
        }
    }
}
