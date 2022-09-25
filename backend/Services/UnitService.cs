using tower_battle.Models;

namespace tower_battle.Services
{
    public class UnitService
    {
        public UnitService() { }
        public bool Create()
        {
            GameManager._state.RightPlayerState.Units.Add(new Unit { Position = new Vector2 { X = 20, Y = 0 }, Scale = new Vector2 { X = 10, Y = 10 } });
            GameManager._state.LeftPlayerState.Units.Add(new Unit { Position = new Vector2 { X = 60, Y = 0 }, Scale = new Vector2 { X = 30, Y = 10 } });
            return true;
        }
    }
}
