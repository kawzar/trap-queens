using System.Collections.Generic;
using System.Linq;
using Queens.Models;
using Queens.ViewModels;
using UnityEngine;

namespace Queens.Services
{
    public class CardProviderService
    {
        private List<CardModel> _cardModels;
        private int magicNumber = 20;
        
        public CardProviderService(string json)
        {
            _cardModels = CardParserService.ParseJson(json);
        }

        public CardViewModel GetNextCard(StatsViewModel statsViewModel)
        {
            List<CardModel> queryResult = _cardModels;
            if (statsViewModel.Flow < magicNumber && statsViewModel.Popularity < magicNumber &&
                statsViewModel.Money < magicNumber)
            {
                queryResult.AddRange(_cardModels.Where(x => x.collection == "starter" || x.collection == "" && x.level_lock <= statsViewModel.Round));
            }

            return new CardViewModel(queryResult[Random.Range(0, queryResult.Count)]);
        }
    }
}