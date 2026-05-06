using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesTransitionManager : MonoBehaviour
{
    public static void TransitionToMainMenu()
    {
        SceneManager.LoadScene(GameScenes.MainMenu);
    }

    public static void TransitionOnStartGameButtonPress()
    {
        // temporary, later should transition to campaign scene
        SceneManager.LoadScene(GameScenes.Ares);
    }
    public static void ReloadActiveScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
