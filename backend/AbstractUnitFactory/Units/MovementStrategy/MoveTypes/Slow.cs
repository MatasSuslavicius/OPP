namespace tower_battle.AbstractUnitFactory.Units.MovementStrategy.MoveTypes
{
    public class Slow : MoveStrategy
    {
        public override void MoveDifferently(Unit unit)
        {
            unit.Speed = 1.5f;
        }
    }
}
