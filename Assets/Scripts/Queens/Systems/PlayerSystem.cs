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
                    
                    PlayerViewModel.Stats.Flow = PlayerViewModel.Stats.Flow + args.FlowDelta;
                    PlayerViewModel.Stats.Health = PlayerViewModel.Stats.Health + args.HealthDelta;
                    PlayerViewModel.Stats.Money = PlayerViewModel.Stats.Money + args.MoneyDelta;
                    PlayerViewModel.Stats.Popularity = PlayerViewModel.Stats.Popularity + args.PopularityDelta;
                    new PlayerEvent(playerArgs).Raise();  
                    PlayerViewModel.Career++;
                    playerArgs.EventType = PlayerEventEnum.EXTEND_CAREER;
                    new PlayerEvent(playerArgs).Raise();
                    break;
            }
        }
    }
}