using UnityEngine;

namespace Queens.Managers
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager Instance { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void LoadScene(int scene)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }

        public int CurrentScene => UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    }
}