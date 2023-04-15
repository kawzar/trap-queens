using Queens.ViewModels;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Queens.Views
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private Image _flow;

        [SerializeField] private Image _money;

        [SerializeField] private Image _popularity;

        [SerializeField] private Image _health;
        
        private StatsViewModel _viewModel;

        public void Bind(StatsViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.Flow.Subscribe(next =>_flow.fillAmount = next * 0.01f);
            _viewModel.Health.Subscribe(next => _health.fillAmount = next * 0.01f);
            _viewModel.Money.Subscribe(next => _money.fillAmount = next * 0.01f);
            _viewModel.Popularity.Subscribe(next => _popularity.fillAmount = 0.01f* next);
        }
    }
}
