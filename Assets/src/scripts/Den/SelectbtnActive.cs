using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectbtnActive : MonoBehaviour
{
    //2D 토끼 ui 클릭 시 Select버튼 SetActive

    //public GameObject[] denInRabbits;
    public GameObject[] btnSelects;
    public static int rabbitIndex;

    public void Selectbtn001()
    {
        rabbitIndex = 0;
        Debug.Log(rabbitIndex);
        btnSelects[rabbitIndex].SetActive(true);
        
    }

    public void Selectbtn002()
    {
        rabbitIndex = 1;
        Debug.Log(rabbitIndex);
        btnSelects[rabbitIndex].SetActive(true);
    }

    public void Selectbtn003()
    {
        rabbitIndex = 2;
        Debug.Log(rabbitIndex);
        btnSelects[rabbitIndex].SetActive(true);
    }

    public void Selectbtn004()
    {
        rabbitIndex = 3;
        Debug.Log(rabbitIndex);
        btnSelects[rabbitIndex].SetActive(true);
    }


}
