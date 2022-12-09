using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Queens.Models;
using UnityEngine;
using UnityEngine.Networking;

namespace Queens.Services
{
    public class CardFactory : MonoBehaviour
    {
        public string FileName = "cards.json";

        private List<CardModel> savedCards = new List<CardModel>();

        private void Awake()
        {
#if UNITY_EDITOR
            var path = Path.Combine(Application.streamingAssetsPath, FileName);
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                savedCards = CardParserService.ParseJson(string.Join(Environment.NewLine, lines));
            }
#else
            StartCoroutine(LoadCardsForWebGL());
#endif
        }

        public List<CardModel> GetSavedCards()
        {
            return savedCards;
        }
        
        IEnumerator LoadCardsForWebGL()
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, FileName);
            UnityWebRequest www = UnityWebRequest.Get(filePath);
            yield return www.SendWebRequest();
 
            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            }
            else 
            {
                savedCards = CardParserService.ParseJson(string.Join(Environment.NewLine, www.downloadHandler.text));
            }
        }
    }
}