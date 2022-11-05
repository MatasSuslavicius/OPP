using tower_battle.Services;

namespace tower_battle.AbstractUnitFactory.Units.MovementStrategies
{
    public class SlowMovementStrategy : MovementStrategy
    {
        protected override float Speed => 1f;
        public override void Move(Direction direction, Unit unit)
        {
            unit.Position.X += Speed * GameManager.UPDATE_TIME * (int)direction;
        }
    }
}
