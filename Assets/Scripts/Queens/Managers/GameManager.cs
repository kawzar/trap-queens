using Queens.Services;
using Queens.Systems;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Queens.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private HistoricDataFactory _historicDataFactory;
        [SerializeField] private CardFactory _cardFactory;
        public static GameManager Instance { get; private set; }
        
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void OnPlay()
        {
            SceneManager.LoadScene(1);
        }
        
        public void OnMenu()
        {
            SceneManager.LoadScene(0);
        }


        public void OnCredits()
        {
            SceneManager.LoadScene(3);
        }
        
        public void OnPlayerLost()
        {
                    _historicDataFactory.AddHistoricData(PlayerSystem.Instance.PlayerViewModel.Value);
                    SceneManager.LoadScene(2);
        }
    }
}
