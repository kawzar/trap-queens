﻿using Queens.Systems.CardFlow;
using UnityEngine;
using UnityEngine.Events;

namespace Queens.Systems.Player
{
    public class PlayerFlowEventListener : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent<PlayerFlowEventArgs> effect;

        private void OnEnable() 
        {
            Debug.Log(gameObject.name);
            PlayerFlowSystem.Instance.Suscribe(this);
        }

        private void OnDisable() 
        {
            PlayerFlowSystem.Instance.Unsuscribe(this);
        }

        public void OnEventRaised(PlayerFlowEventArgs args) 
        {
            Debug.Log(gameObject.name);
            effect.Invoke(args);
        }
    }
}