using Queens.Services;
using Queens.Systems.CardFlow;
using Queens.ViewModels;
using UnityEngine;

namespace Queens.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CardFlowSystem _cardFlowSystem;
        [SerializeField] private TextAsset _cards;

        [SerializeField] private Transform _playground;
        [SerializeField] private CardView _cardPrefab;
        private CardProviderService _cardProviderService;
        private void OnEnable()
        {
            _cardProviderService = new CardProviderService(_cards.text);
            var card = _cardProviderService.GetNextCard();
            var instantiated = Instantiate(_cardPrefab, _playground);
            instantiated.Bind(new CardViewModel
            {
                Bearer = card.bearer, Collection = card.collection, Dialog = card.dialog, Id = card.id,
                level_lock = card.level_lock, Name = card.name,
                No_answer = card.no_answer, Yes_answer = card.yes_answer,
                NoAnswerArgs = new CardFlowEventArgs
                {
                    EventType = CardFlowEventEnum.NO,
                    FlowDelta = card.no_flow.HasValue ? card.no_flow.Value : 0,
                    MoneyDelta = card.no_money.HasValue ? card.no_money.Value : 0,
                    PopularityDelta = card.no_popularity.HasValue ? card.no_popularity.Value : 0,
                    HealthDelta = card.no_health.HasValue ? card.no_health.Value : 0,
                },
                YesAnswerArgs = new CardFlowEventArgs
                {
                    EventType = CardFlowEventEnum.YES,
                    FlowDelta = card.yes_flow.HasValue ? card.yes_flow.Value : 0,
                    MoneyDelta = card.yes_money.HasValue ? card.yes_money.Value : 0,
                    PopularityDelta = card.yes_popularity.HasValue ? card.yes_popularity.Value : 0,
                    HealthDelta = card.yes_health.HasValue ? card.yes_health.Value : 0,
                }
            });
        }

        public void DebugMethod(CardFlowEventArgs args) 
        {
            Debug.Log($"Answer: [{args.EventType}]");
        }
    }
}
