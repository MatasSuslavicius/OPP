using tower_battle.Models;
using tower_battle.Services;

namespace tower_battle.AbstractUnitFactory.Units.MovementStrategies
{
    public class NormalMovementStrategy : MovementStrategy
    {
        public override float GetCurrentSpeed()
        {
            return 2f;
        }

        public override Vector2 GetCurrentPosition(Unit unit)
        {
            return unit.Position;
        }

        public override Vector2 CalculateNextPosition(Vector2 currentPosition, float speed, Direction direction)
        {
            return new Vector2
            {
                X = currentPosition.X + speed * GameManager.UPDATE_TIME * (int) direction, 
                Y = currentPosition.Y
            };
        }

        public override void UpdatePosition(Unit unit, Vector2 position)
        {
            unit.Position = position;
        }
    }
}
