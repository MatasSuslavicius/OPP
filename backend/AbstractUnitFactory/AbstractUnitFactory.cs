using tower_battle.AbstractUnitFactory.Units;

namespace tower_battle.AbstractUnitFactory
{
    public abstract class AbstractUnitFactory
    {
        public abstract Unit CreateMelee(bool isLeft);
        public abstract Unit CreateFastMelee();
    }
}
