using Queens.ViewModels;

namespace Queens.Systems.Player
{
    public class PlayerEvent
    {
        private PlayerFlowEventArgs args;

        public PlayerEvent(PlayerFlowEventArgs args)
        {
            this.args = args;
        }

        public void Raise()
        {
            PlayerFlowSystem.Instance.OnPlayerFlowEventTriggered(args);
        }
    }
    
    public enum PlayerEventEnum
    {
        EXTEND_CAREER,
        STATS_EFFECT,
        ROUND_END
    }

    public class PlayerFlowEventArgs
    {
        public PlayerEventEnum EventType { get; set; }
    }
}