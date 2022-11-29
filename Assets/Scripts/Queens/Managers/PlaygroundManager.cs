using System.Collections;
using Queens.Systems;
using Queens.Systems.CardFlow;
using TMPro;
using UnityEngine;

namespace Queens.Managers
{
    public class PlaygroundManager : MonoBehaviour
    {
        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private TextMeshProUGUI _dialogText;
        
        private void Start()
        {
            PollNextCard(null);
        }

        public void PollNextCard(CardFlowEventArgs args)
        {
            StartCoroutine(WaitBeforePolling());
            var instantiated = Instantiate(_cardPrefab, transform);
            _dialogText.SetText(DeckSystem.Instance.CurrentCard.Dialog);
        }

        IEnumerator WaitBeforePolling()
        {
            yield return new WaitForSeconds(0.25f);
        }
    }
}
