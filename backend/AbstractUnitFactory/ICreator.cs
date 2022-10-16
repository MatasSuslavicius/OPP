using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory
{
    public interface ICreator
    {
        public AbstractUnitFactory GetUnitFactory(int level, PlayerType playerType);
    }
}
