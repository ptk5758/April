using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectbtnActive : MonoBehaviour
{
    //2D �䳢 ui Ŭ�� �� Select��ư SetActive

    //public GameObject[] denInRabbits;
    public GameObject[] btnSelects;
    public static int rabbitIndex;

    public void Selectbtn001()
    {
        rabbitIndex = 0;
        Debug.Log(rabbitIndex);
        btnSelects[rabbitIndex].SetActive(true);
        
    }

    public void InactiveSelectBtn001()
    {
        //rabbit�ε��� �ʱ�ȭ + selectbtn Ŭ�� �� ��Ȱ��ȭ
        rabbitIndex = 0;
        btnSelects[rabbitIndex].SetActive(false);
        SceneManager.LoadScene("ready");
    }

    public void Selectbtn002()
    {
        rabbitIndex = 1;
        Debug.Log(rabbitIndex);
        btnSelects[rabbitIndex].SetActive(true);
    }
    public void InactiveSelectBtn002()
    {
        rabbitIndex = 1;
        btnSelects[rabbitIndex].SetActive(false);
        SceneManager.LoadScene("ready");
    }
    public void Selectbtn003()
    {
        rabbitIndex = 2;
        Debug.Log(rabbitIndex);
        btnSelects[rabbitIndex].SetActive(true);
    }
    public void InactiveSelectBtn003()
    {
        rabbitIndex = 2;
        btnSelects[rabbitIndex].SetActive(false);
        SceneManager.LoadScene("ready");
    }

    public void Selectbtn004()
    {
        rabbitIndex = 3;
        Debug.Log(rabbitIndex);
        btnSelects[rabbitIndex].SetActive(true);
    }
    public void InactiveSelectBtn004()
    {
        rabbitIndex = 3;
        btnSelects[rabbitIndex].SetActive(false);
        SceneManager.LoadScene("ready");
    }

}
