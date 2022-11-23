using Queens.Systems.CardFlow;
using Queens.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Queens.Views
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private Slider _flow;

        [SerializeField] private Slider _money;

        [SerializeField] private Slider _popularity;

        [SerializeField] private Slider _health;

        private StatsViewModel _viewModel;
        
        public void Bind(StatsViewModel viewModel)
        {
            _viewModel = viewModel;
            RebindValues();
        }

        private void RebindValues()
        {
            _flow.value = _viewModel.Flow;
            _money.value = _viewModel.Money;
            _popularity.value = _viewModel.Popularity;
            _health.value = _viewModel.Health;
        }
        
        public void OnCardPlayed(CardFlowEventArgs args)
        {
            if (args == null || args.EventType == CardFlowEventEnum.DRAW) return;
            _viewModel.Flow += args.FlowDelta;
            _viewModel.Money += args.MoneyDelta;
            _viewModel.Popularity += args.PopularityDelta;
            _viewModel.Health += args.HealthDelta;
            RebindValues();
        }
    }
}
