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
                FlowDelta = card.no_flow.HasValue ? card.no_flow.Value : 0,
                MoneyDelta = card.no_money.HasValue ? card.no_money.Value : 0,
                PopularityDelta = card.no_popularity.HasValue ? card.no_popularity.Value : 0,
                HealthDelta = card.no_health.HasValue ? card.no_health.Value : 0,
            };
            YesAnswerArgs = new CardFlowEventArgs
            {
                CardId = Id,
                EventType = CardFlowEventEnum.YES,
                FlowDelta = card.yes_flow.HasValue ? card.yes_flow.Value : 0,
                MoneyDelta = card.yes_money.HasValue ? card.yes_money.Value : 0,
                PopularityDelta = card.yes_popularity.HasValue ? card.yes_popularity.Value : 0,
                HealthDelta = card.yes_health.HasValue ? card.yes_health.Value : 0,
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
