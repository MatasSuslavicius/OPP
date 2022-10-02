using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.Level2;

namespace tower_battle.AbstractUnitFactory.Factories
{
    public class Level2Factory : AbstractUnitFactory
    {
        public override Unit CreateMelee()
        {
            return new Level2Melee();
        }

        public override Unit CreateFastMelee()
        {
            return new Level2FastMelee();
        }
    }
}
