using Queens.Systems;
using Queens.Systems.Player;
using Queens.ViewModels;
using TMPro;
using UnityEngine;

namespace Queens.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private StatsView statsView;
        [SerializeField] private TextMeshProUGUI careerText;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private PlayerViewModel _viewModel;
        
        private void Start()
        {
            _viewModel = PlayerSystem.Instance.PlayerViewModel;
            statsView.Bind(_viewModel.Stats);
            Debug.Log(_viewModel.Name);
            nameText.SetText(_viewModel.Name);
            careerText.SetText($"{_viewModel.Career} meses en carrera");
        }
        
        public void OnStatsChanged(PlayerFlowEventArgs args)
        {
            switch (args.EventType)
            {
                case PlayerEventEnum.STATS_EFFECT:
                    _viewModel = PlayerSystem.Instance.PlayerViewModel;
                    statsView.Bind(_viewModel.Stats);

                    if (!_viewModel.Stats.AreStatsValid())
                    {
                        args.EventType = PlayerEventEnum.ROUND_END;
                        new PlayerEvent(args).Raise();
                    }
                    break;
                case PlayerEventEnum.EXTEND_CAREER:
                    _viewModel = PlayerSystem.Instance.PlayerViewModel;
                    careerText.SetText($"{_viewModel.Career} meses en carrera");
                    nameText.SetText(_viewModel.Name);
                    break;
            }
        }
    }
}