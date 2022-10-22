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
                var collidingWith = UnitColliding(leftPlayerUnit, state);
                if(collidingWith == CollidingWith.NoOne)
                {
                    leftPlayerUnit.Position.X += leftPlayerUnit.Speed * GameManager.UPDATE_TIME;
                }
                else if (collidingWith == CollidingWith.RightPlayerUnit)
                {
                    //damage
                    state.RightPlayerState.Experience += leftPlayerUnit.KillReward;
                    state.RightPlayerState.Money += leftPlayerUnit.KillReward;
                }
            }

            foreach (var rightPlayerUnit in state.RightPlayerState.Units)
            {
                var collidingWith = UnitColliding(rightPlayerUnit, state);
                if (collidingWith == CollidingWith.NoOne)
                {
                    rightPlayerUnit.Position.X -= rightPlayerUnit.Speed * GameManager.UPDATE_TIME;
                }
                else if (collidingWith == CollidingWith.LeftPlayerUnit)
                {
                    //damage
                    state.LeftPlayerState.Experience += rightPlayerUnit.KillReward;
                    state.LeftPlayerState.Money += rightPlayerUnit.KillReward;
                }
            }
        } 

        private static CollidingWith UnitColliding(Unit unit, GameStateSingleton state)
        {
            foreach(Unit leftPlayerUnit in state.LeftPlayerState.Units)
            {
                if(unit != leftPlayerUnit && 
                    PositionRangesOverlap(
                        unit.Position.X + (unit.Scale.X / 2),
                        leftPlayerUnit.Position.X - (leftPlayerUnit.Scale.X / 2),
                        leftPlayerUnit.Position.X + (leftPlayerUnit.Scale.X / 2)))
                {
                    return CollidingWith.LeftPlayerUnit;
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
                    return CollidingWith.RightPlayerUnit;
                }
            }

            return CollidingWith.NoOne;
        }

        private static bool PositionRangesOverlap(float aEnd, float bStart, float bEnd)
        {
            return aEnd > bStart && aEnd < bEnd;
        }
    }
}
