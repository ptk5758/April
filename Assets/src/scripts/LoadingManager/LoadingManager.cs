using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static string sceneName;

    void Start()
    {
        StartCoroutine(LoadingCoroutine());
    }

    public static void LoadScene(string name)
    {
        sceneName = name;
        SceneManager.LoadScene("LoadingScene");
    }

    private IEnumerator LoadingCoroutine()
    {
        
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            yield return null;
            if (asyncOperation.progress >= 0.9f)
            {
                yield return new WaitForSecondsRealtime(6f);
                asyncOperation.allowSceneActivation = true;
            }
        }
        // SceneManager.LoadScene(sceneName);
    }
}
