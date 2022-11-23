namespace Queens.Systems.CardFlow
{
    public enum CardFlowEventEnum
    {
        YES,
        NO,
        DRAW
    }

    public class CardFlowEventArgs
    {
        public int CardId { get; set; }
        public CardFlowEventEnum EventType { get; set; }
        public int FlowDelta { get; set; }
        public int MoneyDelta { get; set; }
        public int PopularityDelta { get; set; }
        public int HealthDelta { get; set; }
        
        public string CardText { get; set; }
    }
}