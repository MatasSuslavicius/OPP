using tower_battle.Models;

namespace tower_battle.Services
{
    public class UnitService
    {
        public UnitService() { }
        public bool Create()
        {
            GameManager._state.RightPlayerState.Units.Add(
                new Unit { 
                    Position = new Vector2 { X = 800, Y = 515 }, 
                    Scale = new Vector2 { X = 20, Y = 40 } 
                });
            GameManager._state.LeftPlayerState.Units.Add
                (new Unit { 
                    Position = new Vector2 { X = 80, Y = 515 }, 
                    Scale = new Vector2 { X = 20, Y = 40 } 
                });
            return true;
        }
    }
}
