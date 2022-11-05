using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
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
                var (collidingWith, collidingUnit) = UnitColliding(leftPlayerUnit, state);
                if(collidingWith == CollidingWith.NoOne)
                {
                    leftPlayerUnit.UnitType.MovementStrategy.Move(Direction.Right, leftPlayerUnit);
                }
                else if (collidingWith == CollidingWith.RightPlayerUnit)
                {
                    leftPlayerUnit.DealDamage(collidingUnit);
                    if (collidingUnit.Health <= 0)
                    {
                        state.RightPlayerState.KillUnit(collidingUnit);
                    }
                }
            }

            foreach (var rightPlayerUnit in state.RightPlayerState.Units)
            {
                var (collidingWith, collidingUnit) = UnitColliding(rightPlayerUnit, state);
                if (collidingWith == CollidingWith.NoOne)
                {
                    rightPlayerUnit.UnitType.MovementStrategy.Move(Direction.Left, rightPlayerUnit);
                }
                else if (collidingWith == CollidingWith.LeftPlayerUnit)
                {
                    rightPlayerUnit.DealDamage(collidingUnit);
                    if (collidingUnit.Health <= 0)
                    {
                        state.LeftPlayerState.KillUnit(collidingUnit);
                    }
                }
            }
        } 

        private static (CollidingWith, Unit?) UnitColliding(Unit unit, GameStateSingleton state)
        {
            foreach(Unit leftPlayerUnit in state.LeftPlayerState.Units)
            {
                if(unit != leftPlayerUnit && leftPlayerUnit.Type != "Turret" &&
                   PositionRangesOverlap(
                       unit.Position.X - (unit.Scale.X / 2),
                       unit.Position.X + (unit.Scale.X / 2),
                       leftPlayerUnit.Position.X - (leftPlayerUnit.Scale.X / 2),
                       leftPlayerUnit.Position.X + (leftPlayerUnit.Scale.X / 2),
                       unit.Type == "Turret"))
                {
                    return (CollidingWith.LeftPlayerUnit, leftPlayerUnit);
                }
            }

            foreach (Unit rightPlayerUnit in state.RightPlayerState.Units)
            {
                if (unit != rightPlayerUnit && rightPlayerUnit.Type != "Turret" &&
                    PositionRangesOverlap(
                        unit.Position.X + (unit.Scale.X / 2),
                        unit.Position.X - (unit.Scale.X / 2),
                        rightPlayerUnit.Position.X - (rightPlayerUnit.Scale.X / 2),
                        rightPlayerUnit.Position.X + (rightPlayerUnit.Scale.X / 2),
                        unit.Type == "Turret"))
                {
                    return (CollidingWith.RightPlayerUnit, rightPlayerUnit);
                }
            }

            return (CollidingWith.NoOne, null);
        }

        private static bool PositionRangesOverlap(float aStart, float aEnd, float bStart, float bEnd, bool isTurret = false)
        {
            if (isTurret)
            {
                return aStart > bStart && aStart < bEnd;
            }
            return aEnd > bStart && aEnd < bEnd;
        }
    }
}
