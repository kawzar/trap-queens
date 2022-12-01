using System.Collections.Generic;
using UnityEngine;

namespace Queens.Systems.Player
{
    [CreateAssetMenu]
    public class PlayerFlowSystem : ScriptableObject
    {
        public static PlayerFlowSystem Instance { get; set; }

        private Dictionary<string, PlayerFlowEventListener> eventListeners =
            new Dictionary<string, PlayerFlowEventListener>();

        private void OnEnable()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Suscribe(PlayerFlowEventListener gameEventListener)
        {
            if(eventListeners.ContainsKey(gameEventListener.name)) return;
            eventListeners.Add(gameEventListener.name, gameEventListener);
        }
        
        public void Unsuscribe(PlayerFlowEventListener gameEventListener)
        {
            eventListeners.Remove(gameEventListener.name);
        }

        public void OnPlayerFlowEventTriggered(PlayerFlowEventArgs args)
        {
            foreach (var eventListener in eventListeners.Values)
            {
                eventListener.OnEventRaised(args);
            }
        }
    }
}