using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DenToReady : MonoBehaviour
{
    //Den ������ Ready ������ �Ѿ��

    public void MoveToReady()
    {
        SceneManager.LoadScene("ready");
        //Debug.Log("ready ������ �̵�");
    }
}
