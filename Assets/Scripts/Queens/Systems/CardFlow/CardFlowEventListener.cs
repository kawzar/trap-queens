using UnityEngine;
using UnityEngine.Events;

namespace Queens.Systems.CardFlow
{
    public class CardFlowEventListener : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent<CardFlowEventArgs> effect;

        private void OnEnable() 
        {
            CardFlowSystem.Instance.Suscribe(this);
        }

        private void OnDisable() 
        {
            CardFlowSystem.Instance.Unsuscribe(this);
        }

        public void OnEventRaised(CardFlowEventArgs args) 
        {
           effect.Invoke(args);
        }
    }
}