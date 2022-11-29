using Queens.Models;
using Queens.Systems.CardFlow;

namespace Queens.ViewModels
{
    public class CardViewModel 
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Bearer { get; set; }
        public string Collection{ get; set; }
        public string Dialog{ get; set; }
        
        public int? level_lock{ get; set; }

        public CardFlowEventArgs YesAnswerArgs;
        public CardFlowEventArgs NoAnswerArgs;
        public CardFlowEventArgs CardDrawnArgs;

        public CardViewModel(CardModel card)
        {
            Bearer = card.bearer;
            Collection = card.collection;
            Dialog = card.dialog;
            Id = card.id;
            level_lock = card.level_lock;
            Name = card.name;
            
            NoAnswerArgs = new CardFlowEventArgs
            {
                CardId = Id,
                EventType = CardFlowEventEnum.NO,
                FlowDelta = card.no_flow,
                MoneyDelta = card.no_money,
                PopularityDelta = card.no_popularity,
                HealthDelta = card.no_health,
            };
            YesAnswerArgs = new CardFlowEventArgs
            {
                CardId = Id,
                EventType = CardFlowEventEnum.YES,
                FlowDelta = card.yes_flow,
                MoneyDelta = card.yes_money,
                PopularityDelta = card.yes_popularity,
                HealthDelta = card.yes_health,
            };
            CardDrawnArgs = new CardFlowEventArgs
            {
                CardId = Id,
                EventType = CardFlowEventEnum.DRAW,
                CardText = Dialog
            };
        }
    }
}
