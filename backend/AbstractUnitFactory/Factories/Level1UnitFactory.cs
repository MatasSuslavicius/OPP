using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.Level1;
using tower_battle.Models;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy.MoveTypes;
using tower_battle.AbstractUnitFactory.Builder;

namespace tower_battle.AbstractUnitFactory.Factories
{
    public class Level1UnitFactory : AbstractUnitFactory
    {
        public Level1UnitFactory(PlayerType playerType): base(playerType) { }
        
        public override Unit CreateNormalMelee()
        {
            Unit unit = new Level1NormalMelee {Position = SpawnPosition, Type = "normal"};
            IBuilder builder = new NormalMeleeBuilder(unit);
            return Director.ConstructLevel1(builder, new Normal());
        }
        public override Unit CreateFastMelee()
        {
            Unit unit = new Level1FastMelee  {Position = SpawnPosition, Type = "fast" };
            IBuilder builder = new FastMeleeBuilder(unit);
            return Director.ConstructLevel1(builder, new Fast());
        }
        public override Unit CreateSlowMelee()
        {
            Unit unit = new Level1SlowMelee {Position = SpawnPosition, Type = "slow" };
            IBuilder builder = new SlowMeleeBuilder(unit);
            return Director.ConstructLevel1(builder, new Slow());
        }
    }
}
