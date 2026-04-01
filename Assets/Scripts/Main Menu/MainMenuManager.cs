using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
