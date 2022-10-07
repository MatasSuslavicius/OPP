namespace tower_battle.AbstractUnitFactory.Units.MovementStrategy.MoveTypes
{
    public class Normal : MoveStrategy
    {

        public override void MoveDifferently(Unit unit)
        {
            unit.Speed = 3f;
        }
    }
}
