using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Models;
using tower_battle.AbstractUnitFactory.Builder;
using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.AbstractUnitFactory.Units.Types;

namespace tower_battle.AbstractUnitFactory.Factories
{
    public class BronzeAgeUnitFactory : AbstractUnitFactory
    {
        public BronzeAgeUnitFactory(PlayerType playerType): base(playerType) { }
        public override Unit CreateSoldier()
        {
            IUnitTypeBuilder unitTypeBuilder = new SoldierUnitTypeBuilder(new SoldierType());
            var unitType = Director.ConstructStoneAgeUnitType(unitTypeBuilder, new NormalMovementStrategy());
            
            Unit unit = new BronzeAgeUnit { Position = SpawnPosition, UnitType = unitType };

            return unit;
        }

        public override Unit CreateScout()
        {
            IUnitTypeBuilder unitTypeBuilder = new ScoutUnitTypeBuilder(new ScoutType());
            var unitType = Director.ConstructStoneAgeUnitType(unitTypeBuilder, new FastMovementStrategy());
            
            Unit unit = new BronzeAgeUnit { Position = SpawnPosition, UnitType = unitType };

            return unit;
        }
        public override Unit CreateTank()
        {
            IUnitTypeBuilder unitTypeBuilder = new TankUnitTypeBuilder(new TankType());
            var unitType = Director.ConstructStoneAgeUnitType(unitTypeBuilder, new SlowMovementStrategy());
            
            Unit unit = new BronzeAgeUnit { Position = SpawnPosition, UnitType = unitType };

            return unit;
        }
    }
}
