using System.Collections;
using Queens.Services;
using Queens.Systems.CardFlow;
using Queens.ViewModels;
using Queens.Views;
using TMPro;
using UnityEngine;

namespace Queens.Managers
{
    public class PlaygroundManager : MonoBehaviour
    {
        [SerializeField] private CardFlowSystem _cardFlowSystem;
        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private TextAsset _cards;
        [SerializeField] private StatsView _stats;
        [SerializeField] private TextMeshProUGUI _dialogText;
        [SerializeField] private TextMeshProUGUI _careerText;
        
        private CardProviderService _cardProviderService;

        private StatsViewModel _statsViewModel = new StatsViewModel { Flow = 25, Health = 25, Money = 25, Popularity = 25 };
        
        private void OnEnable()
        {
            _stats.Bind(_statsViewModel);
            _cardProviderService = new CardProviderService(_cards.text);
            PollNextCard(null);
        }

        public void PollNextCard(CardFlowEventArgs args)
        {
            StartCoroutine(WaitBeforePolling());
            var card = _cardProviderService.GetNextCard(_statsViewModel);
            _dialogText.SetText(card.CardDrawnArgs.CardText);
            var instantiated = Instantiate(_cardPrefab, transform);
            instantiated.Bind(card);
            _statsViewModel.Round++;
            Debug.Log(_statsViewModel.Round);
        }

        IEnumerator WaitBeforePolling()
        {
            yield return new WaitForSeconds(0.25f);
        }
    }
}
