using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{ 
    public void ClickStart()
    {
        Debug.Log("로딩씬으로 이동");
        LoadingManager.sceneName = "Ready";
        SceneManager.LoadScene("LoadingScene");
    }
}
