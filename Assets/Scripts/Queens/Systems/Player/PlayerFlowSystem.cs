using System.Collections.Generic;
using UnityEngine;

namespace Queens.Systems.Player
{
    [CreateAssetMenu]
    public class PlayerFlowSystem : ScriptableObject
    {
        public static PlayerFlowSystem Instance { get; set; }
        private List<PlayerFlowEventListener> eventListeners = new List<PlayerFlowEventListener>();

        private void OnEnable()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Suscribe(PlayerFlowEventListener gameEventListener)
        {
            eventListeners.Add(gameEventListener);
        }
        
        public void Unsuscribe(PlayerFlowEventListener gameEventListener)
        {
            eventListeners.Remove(gameEventListener);
        }

        public void OnCardFlowEventTriggered(PlayerFlowEventArgs args)
        {
            for (int i = 0; i < eventListeners.Count; i++)
            {
                eventListeners[i].OnEventRaised(args);
            }
        }
    }
}