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

    [SerializeField]
    ReadyRabbit readyRabbit;

    

    private void Awake()
    {
        
    }

    private void Start()
    {
        readyRabbit.SelectRabbit(Player.selectRabbitId);
    }

    public void ActivationLevelSelectBoard(bool state)
    {
        ReadyRabbit.current.SetActive(!state);
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
        Debug.Log(asyncOperation.progress);
        while (!asyncOperation.isDone)
        {   
            if (asyncOperation.progress >= 0.9f)
            {                
                yield return new WaitForSeconds(2f);
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    public void LoadDenScene()
    {
        SceneManager.LoadScene("Den");
    }
    private void OnEnable()
    {
        Time.timeScale = 1;
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

[System.Serializable]
class ReadyRabbit
{
    public static GameObject current;

    [SerializeField]
    GameObject[] rabbitPrefabs;

    [SerializeField]
    Transform field;

    public void SelectRabbit(int value)
    {
        GameObject rabbit = GameObject.Instantiate(rabbitPrefabs[value], field);
        current = rabbit;

    }
}