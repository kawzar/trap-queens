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
            PlayerFlowSystem.Instance.OnCardFlowEventTriggered(args);
        }
    }
    
    public enum PlayerEventEnum
    {
        EXTEND_CAREER,
        STATS_EFFECT
    }

    public class PlayerFlowEventArgs
    {
        public PlayerEventEnum EventType { get; set; }
        public int Flow { get; set; }
        public int Money { get; set; }
        public int Health { get; set; }
        public int Popularity { get; set; }
        public int Career { get; set; }
    }
}