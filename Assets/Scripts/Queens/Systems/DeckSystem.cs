using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Queens.Models;
using Queens.Services;
using Queens.ViewModels;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Queens.Systems
{
    public class DeckSystem : MonoBehaviour
    {
        [SerializeField] private CardFactory _cardFactory;
        
        private List<CardModel> allCards;
        private List<int> usedCardIds = new List<int>();
        private Dictionary<string, List<CardModel>> cardsByCollection = new Dictionary<string, List<CardModel>>();

        public IReactiveProperty<CardViewModel> CurrentCardViewModel= new ReactiveProperty<CardViewModel>();
        
        private Subject<CardFlowEventArgs> _cardEventsubject = new Subject<CardFlowEventArgs>();
        public IObservable<CardFlowEventArgs> CardEventObservable => _cardEventsubject.AsObservable();
        
        public static DeckSystem Instance { get; set; }

        private async UniTaskVoid Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
            allCards = await _cardFactory.GetSavedCards();
            CategorizeByCollection();
            CurrentCardViewModel.Value = GetNextCard();
        }

        private CardViewModel GetNextCard()
        {
            List<CardModel> enabledCards = new List<CardModel>();
            foreach (var key in cardsByCollection.Keys)
            {
                if (PlayerSystem.Instance.PlayerViewModel.Value.ActiveCollections.Contains(key) 
                    || string.IsNullOrEmpty(key))
                {
                    enabledCards.AddRange(cardsByCollection[key]);
                }
            }

            // Check level lock and if it already appeared
            for (int i = 0; i < enabledCards.Count; i++)
            {
                if (usedCardIds.Contains(enabledCards[i].id) ||
                    enabledCards[i].level_lock > PlayerSystem.Instance.PlayerViewModel.Value.Career.Value)
                {
                    enabledCards.RemoveAt(i);
                }
            }
            
            if (!enabledCards.Any())
            {
                Debug.LogError("No more cards");
                return null;
            }

            int index = Random.Range(0, enabledCards.Count);
            usedCardIds.Add(enabledCards[index].id);
            return new CardViewModel(enabledCards[index]);
        }

        private void CategorizeByCollection()
        {
            for (int i = 0; i < allCards.Count; i++)
            {
                if (cardsByCollection.ContainsKey(allCards[i].collection))
                {
                    cardsByCollection[allCards[i].collection].Add(allCards[i]);
                }
                else
                {
                    List<CardModel> value = new List<CardModel> { allCards[i] };
                    cardsByCollection.Add(allCards[i].collection, value);
                }
            }
        }
        
        public void CardPlayed(CardFlowEventEnum evt)
        {
            switch (evt)
            {
                case CardFlowEventEnum.YES:
                    _cardEventsubject.OnNext(CurrentCardViewModel.Value.YesAnswerArgs);
                    break;
                case CardFlowEventEnum.NO:
                    _cardEventsubject.OnNext(CurrentCardViewModel.Value.NoAnswerArgs);
                    break;
            }
            
            CurrentCardViewModel.Value = GetNextCard();
        }
    }
}
