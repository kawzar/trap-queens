using Queens.Global.Constants;
using Queens.Services;
using Queens.Systems;
using UnityEngine;

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
            SceneManager.Instance.LoadScene(SceneConstants.PLAY);
        }
        
        public void OnMenu()
        {
            SceneManager.Instance.LoadScene(SceneConstants.MENU);
        }


        public void OnCredits()
        {
            SceneManager.Instance.LoadScene(SceneConstants.CREDITS);
        }

        public void OnPlayerLost()
        {
            _historicDataFactory.AddHistoricData(PlayerSystem.Instance.PlayerViewModel.Value);
            SceneManager.Instance.LoadScene(SceneConstants.LOST);
        }
    }
}
