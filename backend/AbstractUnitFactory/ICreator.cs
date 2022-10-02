namespace tower_battle.AbstractUnitFactory
{
    public interface ICreator
    {
        public AbstractUnitFactory GetUnitFactory(int level);
    }
}
