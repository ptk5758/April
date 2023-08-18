using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyPage : MonoBehaviour
{
    [SerializeField]
    Animator basketAnimator;

    [SerializeField]
    ReadyPageUI readyPageUI;

    public void ActivationLevelSelectBoard(bool state)
    {
        readyPageUI.ActiveLevelSelectBoard(state);
    }

    public void SelectLevel(int value)
    {
        LevelManager.SetGameLevel(value);
        readyPageUI.ActiveLevelSelectBoard(false);
        basketAnimator.SetBool("isDown",true);
        StartCoroutine(LoadScene("level1"));
    }
    IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {   
            if (asyncOperation.progress >= 0.9f)
            {                
                yield return new WaitForSeconds(3f);
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}

[System.Serializable]
class ReadyPageUI
{
    [SerializeField]
    GameObject levelSelectBoard;

    internal void ActiveLevelSelectBoard(bool state)
    {
        levelSelectBoard.SetActive(state);
    }

}