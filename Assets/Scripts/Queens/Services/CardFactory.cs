using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Queens.Models;
using UnityEngine;

namespace Queens.Services
{
    [CreateAssetMenu(fileName = "CardFactory")]
    public class CardFactory : ScriptableObject
    {
        public string FilePath = Application.streamingAssetsPath;
        public string FileName = "cards.json";

        private List<CardModel> savedCards = new List<CardModel>();
        

        public List<CardModel> GetSavedCards()
        {
            if (savedCards.Any()) return savedCards;
            
            var path = Path.Combine(FilePath, FileName);
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                savedCards = CardParserService.ParseJson(string.Join(Environment.NewLine, lines));
            }

            return savedCards;
        }
    }
}