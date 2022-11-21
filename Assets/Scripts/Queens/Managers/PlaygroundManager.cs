using System.Collections;
using Queens.Services;
using Queens.Systems.CardFlow;
using Queens.ViewModels;
using Queens.Views;
using UnityEngine;

namespace Queens.Managers
{
    public class PlaygroundManager : MonoBehaviour
    {
        [SerializeField] private CardFlowSystem _cardFlowSystem;
        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private TextAsset _cards;
        [SerializeField] private StatsView _stats;
        
        private CardProviderService _cardProviderService;
        
        private void OnEnable()
        {
            _stats.Bind(new StatsViewModel{Flow = 25, Health = 25, Money = 25, Popularity = 25});
            _cardProviderService = new CardProviderService(_cards.text);
            PollNextCard(null);
        }

        public void PollNextCard(CardFlowEventArgs args)
        {
            StartCoroutine(WaitBeforePolling());
            var card = _cardProviderService.GetNextCard();
            var instantiated = Instantiate(_cardPrefab, transform);
            instantiated.Bind(new CardViewModel(card));
        }

        IEnumerator WaitBeforePolling()
        {
            yield return new WaitForSeconds(0.25f);
        }
    }
}
