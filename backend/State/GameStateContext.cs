namespace tower_battle.State
{
    public class GameStateContext
    {
        private IGameState m_currentState;

        public GameStateContext()
        {
            m_currentState = new RunningGameState();
        }

        public void SetState(IGameState state)
        {
            m_currentState = state;
        }

        public void Loop()
        {
            m_currentState.Loop(this);
        }
    }
}
