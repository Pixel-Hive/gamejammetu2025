using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Logic logic;
    public void AgainBtn(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

    public void MainMenuBtn()
    {
        SceneManager.LoadScene("MainMenuScreen");
    }
}