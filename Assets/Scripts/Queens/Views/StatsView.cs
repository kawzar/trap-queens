using Queens.ViewModels;
using UniRx;
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
            _viewModel.Flow.Subscribe(next =>_flow.value = next);
            _viewModel.Health.Subscribe(next => _health.value = next);
            _viewModel.Money.Subscribe(next => _money.value = next);
            _viewModel.Popularity.Subscribe(next => _popularity.value = next);
        }
    }
}
