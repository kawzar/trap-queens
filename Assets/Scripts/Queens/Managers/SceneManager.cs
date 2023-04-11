using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Queens.Managers
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _loaderCanvas;
        [SerializeField] private Slider _progressBar;
        
        public static SceneManager Instance { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public async UniTaskVoid LoadScene(int scene)
        {
            var asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene);
            asyncOperation.allowSceneActivation = false;
            _loaderCanvas.gameObject.SetActive(true);

            while (asyncOperation is {isDone: false})
            {
                _progressBar.value = Mathf.Clamp(_progressBar.value, asyncOperation.progress, 0.9f);

                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                    _loaderCanvas.gameObject.SetActive(false);
                    await UniTask.DelayFrame(1);
                }
            }
            
            await UniTask.DelayFrame(1);
        }

        public int CurrentScene => UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    }
}