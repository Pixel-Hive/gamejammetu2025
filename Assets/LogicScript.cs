using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public GameObject gameOverScreen;
    public mcscript script;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenuScreen");
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        script.birdIsAlive = false;
    }

}
