using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LevelMenuScreen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}