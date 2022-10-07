using tower_battle.AbstractUnitFactory.Units;

namespace tower_battle.AbstractUnitFactory
{
    public abstract class AbstractUnitFactory
    {
        public abstract Unit CreateNormalMelee(bool isLeft);
        public abstract Unit CreateFastMelee(bool isLeft);
        public abstract Unit CreateSlowMelee(bool isLeft);
    }
}
