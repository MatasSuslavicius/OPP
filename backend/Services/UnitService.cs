using tower_battle.Models;

namespace tower_battle.Services
{
    public class UnitService
    {
        public UnitService() { }
        public bool Create()
        {
            GameStateSingleton.Instance.RightPlayerState.Units.Add(
                new Unit { 
                    Position = new Vector2 { X = 10, Y = 0 },
                    Scale = new Vector2 { X = 0.5f, Y = 1f }
                });
            GameStateSingleton.Instance.LeftPlayerState.Units.Add
                (new Unit { 
                    Position = new Vector2 { X = -10, Y = 0 }, 
                    Scale = new Vector2 { X = 0.5f, Y = 1f } 
                });
            return true;
        }
    }
}
