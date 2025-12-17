using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Game.Scripts.Util
{
    public class SceneLoaderAsync : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] private Slider loadingSlider;

        public void LoadScene()
        {
            StartCoroutine(LoadSceneAsync());
        }

        private IEnumerator LoadSceneAsync()
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                Debug.LogError("SceneLoaderAsync: Scene name is not set or is empty.");
                yield break;
            }

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            
            if (asyncOperation == null)
            {
                Debug.LogError($"SceneLoaderAsync: Failed to load scene '{sceneName}'. Make sure the scene is added to Build Settings.");
                yield break;
            }
            
            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
                
                if (loadingSlider != null)
                {
                    loadingSlider.value = progress;
                }

                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}
