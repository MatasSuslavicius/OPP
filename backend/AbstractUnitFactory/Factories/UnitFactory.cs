using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Factories
{
    public class UnitFactory : ICreator
    {
        public AbstractUnitFactory GetUnitFactory(int level, PlayerType playerType)
        {
            switch (level)
            {
                case 1:
                    return new Level1UnitFactory(playerType);
                case 2:
                    return new Level2UnitFactory(playerType);
                default:
                    throw new Exception("Invalid level");
            }
        }
    }
}
