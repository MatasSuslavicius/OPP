using tower_battle.Services;

namespace tower_battle.AbstractUnitFactory.Units.MovementStrategies
{
    public class NormalMovementStrategy : MovementStrategy
    {
        protected override float Speed => 2f;
        public override void Move(Direction direction, Unit unit)
        {
            unit.Position.X += Speed * GameManager.UPDATE_TIME * (int)direction;
        }
    }
}
