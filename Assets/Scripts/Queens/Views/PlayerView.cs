using System;
using Queens.Systems;
using Queens.Systems.CardFlow;
using Queens.ViewModels;
using TMPro;
using UnityEngine;

namespace Queens.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private StatsView statsView;
        [SerializeField] private TextMeshProUGUI careerText;

        private PlayerViewModel _viewModel;

        private void Start()
        {
            _viewModel = PlayerSystem.Instance.PlayerViewModel;
            statsView.Bind(_viewModel.Stats);
            careerText.SetText($"{_viewModel.Career} meses en carrera");
        }
        
        public void OnCardPlayed(CardFlowEventArgs args)
        {
            if (args.EventType != CardFlowEventEnum.DRAW) return;
            _viewModel.Career++;
            careerText.SetText($"{_viewModel.Career} meses en carrera");
        }
    }
}