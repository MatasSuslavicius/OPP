using tower_battle.AbstractUnitFactory.Units;

namespace tower_battle.AbstractUnitFactory
{
    public abstract class AbstractUnitFactory
    {
        public abstract Unit CreateMelee();
        public abstract Unit CreateFastMelee();
    }
}
