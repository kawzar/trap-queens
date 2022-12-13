using Queens.Managers;
using Queens.Services;
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

        private void Start()
        {
            DeckSystem.Instance.CardEventObservable.Subscribe(OnCardFlowEventTriggered);
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
                    
                    PlayerViewModel.Value.Career.Value = PlayerViewModel.Value.Career.Value + 1;

                    if (!PlayerViewModel.Value.Stats.AreStatsValid())
                    {
                        GameManager.Instance.OnPlayerLost();
                    }

                    if (!string.IsNullOrEmpty(args.ActivatesCollection))
                    {
                        if (!PlayerViewModel.Value.ActiveCollections.Contains(args.ActivatesCollection))
                        {
                            PlayerViewModel.Value.ActiveCollections.Add(args.ActivatesCollection);
                        }
                    }
                    break;
            }
        }
    }
}