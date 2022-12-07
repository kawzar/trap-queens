using System.Collections.Generic;
using System.Linq;
using Queens.Models;
using Queens.Services;
using Queens.Systems.CardFlow;
using Queens.ViewModels;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Queens.Systems
{
    public class DeckSystem : MonoBehaviour
    {
        [SerializeField] private CardFactory _cardFactory;
        [SerializeField] private CardFlowSystem _cardFlow;
        
        public CardViewModel CurrentCard { get; private set; }

        private List<CardModel> allCards;
        private List<int> usedCardIds = new List<int>();

        public static DeckSystem Instance { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            allCards = _cardFactory.GetSavedCards();
            allCards.RemoveAll(x => x.id == 0); // el mapping lo arreglamo despue
            CurrentCard = GetNextCard();
        }

        private CardViewModel GetNextCard()
        {
            CardViewModel toReturn = null;
            var filtered = allCards.Where(c => !usedCardIds.Contains(c.id))
                .Where(c => c.level_lock <= PlayerSystem.Instance.PlayerViewModel.Career)
                .Where(c => string.IsNullOrEmpty(c.collection) || PlayerSystem.Instance.PlayerViewModel.ActiveCollections.Contains(c.collection))
                .ToArray();

            if (filtered.Any())
            {
                int index = Random.Range(0, filtered.Length);
                toReturn = new CardViewModel(filtered[index]);
                usedCardIds.Add(toReturn.Id);
                Debug.Log($"{toReturn.Bearer}, {toReturn.Name}, {toReturn.Id}");
            }

            return toReturn;
        }

        public void OnCardPlayed(CardFlowEventArgs args)
        {
            CurrentCard = GetNextCard();
        }
    }
}
