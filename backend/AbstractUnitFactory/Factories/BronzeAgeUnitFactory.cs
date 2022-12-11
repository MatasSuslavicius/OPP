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
            IUnitTypeBuilder unitTypeBuilder = new SoldierUnitTypeBuilder(new SoldierType{Scale = new Vector2 { X = 1f, Y = 1f }});
            var unitType = Director.ConstructBronzeAgeUnitType(unitTypeBuilder, new NormalMovementStrategy());
            
            Unit unit = new BronzeAgeUnit { Position = SpawnPosition, UnitType = unitType };

            return unit;
        }

        public override Unit CreateScout()
        {
            IUnitTypeBuilder unitTypeBuilder = new ScoutUnitTypeBuilder(new ScoutType{Scale = new Vector2 {X = 0.75f, Y = 1.25f }});
            var unitType = Director.ConstructBronzeAgeUnitType(unitTypeBuilder, new FastMovementStrategy());
            
            Unit unit = new BronzeAgeUnit { Position = SpawnPosition, UnitType = unitType };

            return unit;
        }
        public override Unit CreateTank()
        {
            IUnitTypeBuilder unitTypeBuilder = new TankUnitTypeBuilder(new TankType{Scale = new Vector2 { X = 1.5f, Y = 0.75f  }});
            var unitType = Director.ConstructBronzeAgeUnitType(unitTypeBuilder, new SlowMovementStrategy());
            
            Unit unit = new BronzeAgeUnit { Position = SpawnPosition, UnitType = unitType };
            return unit;
        }
    }
}
