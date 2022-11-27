using tower_battle.Models;
using tower_battle.Services;

namespace tower_battle.AbstractUnitFactory.Units.MovementStrategies;

public class NullMovementStrategy : MovementStrategy
{
    public override float GetCurrentSpeed()
    {
        return 0;
    }

    public override Vector2 GetCurrentPosition(Unit unit)
    {
        return unit.Position;
    }

    public override Vector2 CalculateNextPosition(Vector2 currentPosition, float speed, Direction direction)
    {
        return currentPosition;
    }

    public override void UpdatePosition(Unit unit, Vector2 position)
    {
    }
}