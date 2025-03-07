using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void BtnLevel1()
    {
        SceneManager.LoadScene("GameScreen1");
    }

    public void BtnLevel2()
    {
        SceneManager.LoadScene("GameScreen2");
    }

    public void BtnLevel3()
    {
        SceneManager.LoadScene("GameScreen3");
    }

    public void BtnLevel4()
    {
        SceneManager.LoadScene("GameScreen4");
    }
}