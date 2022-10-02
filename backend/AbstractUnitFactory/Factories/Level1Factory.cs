using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.Level1;

namespace tower_battle.AbstractUnitFactory.Factories
{
    public class Level1Factory : AbstractUnitFactory
    {
        public override Unit CreateMelee()
        {
            return new Level1Melee();
        }
        public override Unit CreateFastMelee()
        {
            return new Level1FastMelee();
        }
    }
}
