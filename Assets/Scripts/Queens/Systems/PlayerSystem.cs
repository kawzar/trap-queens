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
                case CardFlowEventEnum.DRAW:
                    playerArgs.Career = PlayerViewModel.Career + 1;
                    playerArgs.EventType = PlayerEventEnum.EXTEND_CAREER;
                    _playerFlow.OnCardFlowEventTriggered(playerArgs);
                    break;
                case CardFlowEventEnum.NO:
                case CardFlowEventEnum.YES:
                    playerArgs.EventType = PlayerEventEnum.STATS_EFFECT;
                    playerArgs.Flow = PlayerViewModel.Stats.Flow + args.FlowDelta;
                    playerArgs.Health = PlayerViewModel.Stats.Health + args.HealthDelta;
                    playerArgs.Money = PlayerViewModel.Stats.Money + args.MoneyDelta;
                    playerArgs.Popularity = PlayerViewModel.Stats.Popularity + args.PopularityDelta;
                    _playerFlow.OnCardFlowEventTriggered(playerArgs);
                    break;
            }
        }
    }
}