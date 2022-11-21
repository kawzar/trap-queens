using System.Collections.Generic;
using UnityEngine;

namespace Queens.Systems.CardFlow
{
    [CreateAssetMenu]
    public class CardFlowSystem : ScriptableObject
    {
        public static CardFlowSystem Instance { get; set; }
        private List<CardFlowEventListener> cardFlowEventListeners = new List<CardFlowEventListener>();

        private void OnEnable()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Suscribe(CardFlowEventListener gameEventListener)
        {
            cardFlowEventListeners.Add(gameEventListener);
        }
        
        public void Unsuscribe(CardFlowEventListener gameEventListener)
        {
            cardFlowEventListeners.Remove(gameEventListener);
        }

        public void OnCardFlowEventTriggered(CardFlowEventArgs args)
        {
            for (int i = 0; i < cardFlowEventListeners.Count; i++)
            {
                cardFlowEventListeners[i].OnEventRaised(args);
            }
        }
    }
}
