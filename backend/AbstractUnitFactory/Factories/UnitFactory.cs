namespace tower_battle.AbstractUnitFactory.Factories
{
    public class UnitFactory : ICreator
    {
        public AbstractUnitFactory GetUnitFactory(int level)
        {
            switch (level)
            {
                case 1:
                    return new Level1Factory();
                case 2:
                    return new Level2Factory();
                default:
                    return null;
            }
        }
    }
}
