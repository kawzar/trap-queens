using System.Collections.Generic;
using Queens.Models;
using UnityEngine;

namespace Queens.Services
{
    public class CardProviderService
    {
        private List<CardModel> _cardModels;
        
        public CardProviderService(string json)
        {
            _cardModels = CardParserService.ParseJson(json);
        }

        public CardModel GetNextCard()
        {
            return _cardModels[Random.Range(0, _cardModels.Count)];
        }
    }
}