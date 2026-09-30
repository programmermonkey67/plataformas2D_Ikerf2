using UnityEngine;

public class MenuManager : MonoBehaviour
{
   public void ChangeScene(string sceneName)
   {
    SceneLoader.Instance.ChangeScene(scenename);
   }

   public void QuitGame()
   {
        Application.Quit();
   }
}
