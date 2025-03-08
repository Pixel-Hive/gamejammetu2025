using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image image;

    public void LoadScreen(int sceneId)
    {
        StartCoroutine(LoadScreenAsyn(sceneId));
    }

    IEnumerator LoadScreenAsyn(int sceneId)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneId);
        while (!op.isDone)
        {
            float a = Mathf.Clamp01((float)(op.progress / 0.9));
            LoadingScreen.SetActive(true);
            image.fillAmount = a;
            yield return null;
        }
    }
    
}
