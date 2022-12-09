using Queens.Managers;
using Queens.Services;
using Queens.Systems.CardFlow;
using Queens.Systems.Events;
using Queens.ViewModels;
using UniRx;
using UnityEngine;

namespace Queens.Systems
{
    public class PlayerSystem : MonoBehaviour
    {
        [SerializeField] private PlayerFactory _playerFactory;
        
        public static PlayerSystem Instance { get; private set; }
        public ReactiveProperty<PlayerViewModel> PlayerViewModel { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
            PlayerViewModel = new ReactiveProperty<PlayerViewModel>(new PlayerViewModel(_playerFactory.GetSavedModel()));
        }
        
        public void OnCardFlowEventTriggered(CardFlowEventArgs args)
        {
            switch (args.EventType)
            {
                case CardFlowEventEnum.NO:
                case CardFlowEventEnum.YES:
                    PlayerViewModel.Value.Stats.Flow.Value = PlayerViewModel.Value.Stats.Flow.Value + args.FlowDelta;
                    PlayerViewModel.Value.Stats.Health.Value = PlayerViewModel.Value.Stats.Health.Value + args.HealthDelta;
                    PlayerViewModel.Value.Stats.Money.Value = PlayerViewModel.Value.Stats.Money.Value + args.MoneyDelta;
                    PlayerViewModel.Value.Stats.Popularity.Value = PlayerViewModel.Value.Stats.Popularity.Value + args.PopularityDelta;
                    PlayerViewModel.Value.Career.Value++;

                    if (!PlayerViewModel.Value.Stats.AreStatsValid())
                    {
                        GameManager.Instance.OnPlayerLost();
                    }
                    
                    break;
            }
        }
    }
}