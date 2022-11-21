using Queens.Models;

namespace Queens.Systems.CardFlow
{
    public enum CardFlowEventEnum
    {
        DRAW, 
        YES,
        NO
    }

    public class CardFlowEventArgs
    {
        public CardFlowEventEnum EventType { get; set; }
        public float FlowDelta { get; set; }
        public float MoneyDelta { get; set; }
        public float PopularityDelta { get; set; }
        public float HealthDelta { get; set; }
    }
}