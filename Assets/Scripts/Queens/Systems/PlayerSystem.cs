using Queens.Services;
using Queens.Systems.CardFlow;
using Queens.Systems.Player;
using Queens.ViewModels;
using UnityEngine;

namespace Queens.Systems
{
    public class PlayerSystem : MonoBehaviour
    {
        [SerializeField] private PlayerFactory _playerFactory;
        [SerializeField] private PlayerFlowSystem _playerFlow;
        
        public static PlayerSystem Instance { get; private set; }
        public PlayerViewModel PlayerViewModel { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
            PlayerViewModel = new PlayerViewModel(_playerFactory.GetSavedModel());
        }
        
        public void OnCardFlowEventTriggered(CardFlowEventArgs args)
        {
            var playerArgs = new PlayerFlowEventArgs();

            switch (args.EventType)
            {
                case CardFlowEventEnum.NO:
                case CardFlowEventEnum.YES:
                    playerArgs.EventType = PlayerEventEnum.STATS_EFFECT;
                    
                    PlayerViewModel.Stats.Flow.Value = PlayerViewModel.Stats.Flow.Value + args.FlowDelta;
                    PlayerViewModel.Stats.Health.Value = PlayerViewModel.Stats.Health.Value + args.HealthDelta;
                    PlayerViewModel.Stats.Money.Value = PlayerViewModel.Stats.Money.Value + args.MoneyDelta;
                    PlayerViewModel.Stats.Popularity.Value = PlayerViewModel.Stats.Popularity.Value + args.PopularityDelta;
                    PlayerViewModel.Career.Value++;
                    break;
            }
        }
    }
}