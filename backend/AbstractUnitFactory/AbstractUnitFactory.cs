using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Builder;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory
{
    public abstract class AbstractUnitFactory
    {
        protected Vector2 SpawnPosition;
        protected AbstractUnitFactory(PlayerType playerType)
        {
            if (playerType == PlayerType.Left)
            {
                SpawnPosition = new Vector2 {X = -10, Y = 0};
            }
            else if (playerType == PlayerType.Right)
            {
                SpawnPosition = new Vector2() {X = 10, Y = 0};
            }
        }
        
        protected Director Director = new ();
        public abstract Unit CreateNormalMelee();
        public abstract Unit CreateFastMelee();
        public abstract Unit CreateSlowMelee();
    }
}
