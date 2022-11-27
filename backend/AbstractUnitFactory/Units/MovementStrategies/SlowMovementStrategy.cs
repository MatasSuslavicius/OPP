using tower_battle.Models;
using tower_battle.Services;

namespace tower_battle.AbstractUnitFactory.Units.MovementStrategies
{
    public class SlowMovementStrategy : MovementStrategy
    {
        public override float GetCurrentSpeed()
        {
            return 1f;
        }

        public override Vector2 GetCurrentPosition(Unit unit)
        {
            return unit.Position;
        }

        public override Vector2 CalculateNextPosition(Vector2 currentPosition, float speed, Direction direction)
        {
            var yOffset = (float)Math.Sin(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() * 10) * 2;
            return new Vector2
            {
                X = currentPosition.X + speed * GameManager.UPDATE_TIME * (int) direction, 
                Y = currentPosition.Y + yOffset
            };
        }

        public override void UpdatePosition(Unit unit, Vector2 position)
        {
            unit.Position = position;
        }
    }
}
