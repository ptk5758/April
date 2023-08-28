using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void changeScene()
    {
        Debug.Log("Den으로 전환");
        SceneManager.LoadScene("Den");
    }
}
