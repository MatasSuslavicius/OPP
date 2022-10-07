namespace tower_battle.AbstractUnitFactory.Units.MovementStrategy.MoveTypes
{
    public class Fast : MoveStrategy
    {
        public override void MoveDifferently(Unit unit)
        {
            unit.Speed = 6f;
        }
    }
}
