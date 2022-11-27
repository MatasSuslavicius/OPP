using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units.MovementStrategies
{
    public enum Direction { Right = 1, Left = -1 }
    public abstract class MovementStrategy
    {
        public void Move(Direction direction, Unit unit)
        {
            float speed = GetCurrentSpeed();
            var position = GetCurrentPosition(unit);
            var nextPosition = CalculateNextPosition(position, speed, direction);
            UpdatePosition(unit, nextPosition);
        }

        public abstract float GetCurrentSpeed();

        public abstract Vector2 GetCurrentPosition(Unit unit);
        public abstract Vector2 CalculateNextPosition(Vector2 currentPosition, float speed, Direction direction);
        public abstract void UpdatePosition(Unit unit, Vector2 position);
    }
}
