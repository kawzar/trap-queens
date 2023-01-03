using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Queens.Models;
using UnityEngine;
using UnityEngine.Networking;

namespace Queens.Services
{
    public class CardFactory : MonoBehaviour
    {
        public string FileName = "cards.json";

        private List<CardModel> savedCards = new List<CardModel>();

        private async UniTask LoadSavedCards()
        {
#if UNITY_EDITOR
            await UniTask.RunOnThreadPool(() =>
            {
                var path = Path.Combine(Application.streamingAssetsPath, FileName);
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    savedCards = CardParserService.ParseJson(string.Join(Environment.NewLine, lines));
                }
            });
#else
            string filePath = Path.Combine(Application.streamingAssetsPath, FileName);
            var fileText = await GetTextAsync(UnityWebRequest.Get(filePath));
            savedCards = CardParserService.ParseJson(string.Join(Environment.NewLine, fileText));

#endif
        }

        public async UniTask<List<CardModel>> GetSavedCards()
        {
            await LoadSavedCards();
            return savedCards;
        }
        
        async UniTask<string> GetTextAsync(UnityWebRequest req)
        {
            var op = await req.SendWebRequest();
            return op.downloadHandler.text;
        }
    }
}