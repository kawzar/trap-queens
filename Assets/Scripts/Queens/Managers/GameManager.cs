using System;
using Queens.Services;
using Queens.Systems;
using Queens.Systems.CardFlow;
using Queens.Systems.Events;
using Queens.Systems.Player;
using Queens.ViewModels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Queens.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private HistoricDataFactory _historicDataFactory;
        private void OnEnable()
        {
            
        }

        public void OnPlay()
        {
            
        }

        public void OnPlayerLost(PlayerFlowEventArgs args)
        {
            switch (args.EventType)
            {
                case PlayerEventEnum.ROUND_END:
                    _historicDataFactory.AddHistoricData(PlayerSystem.Instance.PlayerViewModel);
                    SceneManager.LoadScene(1);
                    break;
            }
        }
    }
}
