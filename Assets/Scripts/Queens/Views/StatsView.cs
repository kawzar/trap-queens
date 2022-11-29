using Queens.Systems;
using Queens.Systems.Player;
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
        
        public void OnStatsChanged(PlayerFlowEventArgs args)
        {
            if (args == null || args.EventType == PlayerEventEnum.STATS_EFFECT) return;
            _viewModel = PlayerSystem.Instance.PlayerViewModel.Stats;
            RebindValues();
        }
    }
}
