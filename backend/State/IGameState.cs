namespace tower_battle.State
{
    public interface IGameState
    {
        public void Loop(GameStateContext ctx);
    }
}
