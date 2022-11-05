namespace tower_battle.AbstractUnitFactory.Units.MovementStrategies;

public class NullMovementStrategy : MovementStrategy
{
    public override float Speed => 0f;
    public override void Move(Direction direction, Unit unit)
    {
    }
}