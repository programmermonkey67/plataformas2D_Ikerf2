using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
     public static SceneLoader Instance;

     [SerializeField] private GameObject _loadingCanvas;
     [SerializeField] private Image _loadingBar;

     void Awake()
     {
        if(Instance!=null && Instance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            Instance = this;
        }
     }
        /*public void ChangeScene(stirng sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }*/
        
     public void ChangeScene(string sceneName)
     {
        
     }

     IEnumerator LoadNewScene(string sceneName)
     {
        _loadingCanvas.SetActive(true);

        Asyncoperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        while(asyncLoad.isDone)
        {
            fakeLoadPercentage += 0.01f;
            Mathf.Clamp01(fakeLoadPercentage);

            _loadingBar.fillAmount = fakeLoadPercentage;

            if(asyncLoad.progress >= 0.09f && fakeLoadPercentage >= 0.99f)
            {
                asyncLoad.allowSceneActivation = true;

            }

            yield return new WaitForSecondRealTime(0.1f);
        }
     }
}
