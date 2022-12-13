using Queens.Systems;
using Queens.ViewModels;
using TMPro;
using UniRx;
using UnityEngine;

namespace Queens.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private StatsView statsView;
        [SerializeField] private TextMeshProUGUI careerText;
        [SerializeField] private TextMeshProUGUI nameText;
        
        private void Start()
        {
            PlayerSystem.Instance.PlayerViewModel.Subscribe(OnNextPlayerViewModel);
        }

        private void OnNextPlayerViewModel(PlayerViewModel playerViewModel)
        {
            statsView.Bind(playerViewModel.Stats);
            nameText.SetText(playerViewModel.Name);
            PlayerSystem.Instance.PlayerViewModel.Value.Career.Subscribe(SetCareerText);
        }

        private void SetCareerText(int value)
        {
            careerText.SetText($"{value} meses en carrera");
        }
    }
}