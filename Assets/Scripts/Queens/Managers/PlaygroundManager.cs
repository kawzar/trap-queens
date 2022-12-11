using Queens.Systems;
using Queens.ViewModels;
using TMPro;
using UniRx;
using UnityEngine;

namespace Queens.Managers
{
    public class PlaygroundManager : MonoBehaviour
    {
        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private TextMeshProUGUI _dialogText;
        
        private void Start()
        {
            DeckSystem.Instance.CurrentCardViewModel.Subscribe(OnNext);
        }

        private void OnNext(CardViewModel obj)
        {
            if (obj == null)
            {
                Debug.Log("CardViewModel is null");
                return;
            }
            var instantiated = Instantiate(_cardPrefab, transform);
            _dialogText.SetText(obj.Dialog);
        }
    }
}
