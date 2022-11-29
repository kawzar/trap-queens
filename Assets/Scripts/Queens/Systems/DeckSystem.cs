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
            CurrentCard = GetNextCard();
        }

        private CardViewModel GetNextCard()
        {
            CardViewModel toReturn;
            var filtered = allCards.Where(c => c.level_lock <= PlayerSystem.Instance.PlayerViewModel.Career)
                //.Where(c => string.IsNullOrEmpty(c.collection) ||
                  //          _playerSystem.PlayerViewModel.ActiveCollections.Contains(c.collection))
                .ToList();
            int index = Random.Range(0, filtered.Count);
            toReturn = new CardViewModel(filtered[index]);
            
            
            return toReturn;
        }
    }
}
