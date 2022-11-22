using Queens.Services;
using Queens.Systems.CardFlow;
using Queens.ViewModels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Queens.Managers
{
    public class GameManager : MonoBehaviour
    {
        public void OnPlay()
        {
            SceneManager.LoadScene(0);
        }
    }
}
