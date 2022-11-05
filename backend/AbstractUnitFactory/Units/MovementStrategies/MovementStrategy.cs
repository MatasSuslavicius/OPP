namespace tower_battle.AbstractUnitFactory.Units.MovementStrategies
{
    public enum Direction { Right = 1, Left = -1 }
    public abstract class MovementStrategy
    {
        protected abstract float Speed { get; }
        public abstract void Move(Direction direction, Unit unit);
    }
}
