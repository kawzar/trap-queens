namespace Queens.Systems.CardFlow
{
    public class CardFlowEvent 
    {
        private CardFlowEventArgs args;

        public CardFlowEvent(CardFlowEventArgs args)
        {
            this.args = args;
        }

        public void Raise()
        {
            CardFlowSystem.Instance.OnCardFlowEventTriggered(args);
        }
    }
}