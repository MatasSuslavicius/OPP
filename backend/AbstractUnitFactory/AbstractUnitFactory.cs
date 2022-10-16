using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Builder;

namespace tower_battle.AbstractUnitFactory
{
    public abstract class AbstractUnitFactory
    {
        protected Director director = new Director();
        public abstract Unit CreateNormalMelee(bool isLeft);
        public abstract Unit CreateFastMelee(bool isLeft);
        public abstract Unit CreateSlowMelee(bool isLeft);
    }
}
