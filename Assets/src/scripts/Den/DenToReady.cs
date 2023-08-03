using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DenToReady : MonoBehaviour
{
    //Den 씬에서 Ready 씬으로 넘어가기

    public void MoveToReady()
    {
        SceneManager.LoadScene("ready");
        //Debug.Log("ready 씬으로 이동");
    }
}
