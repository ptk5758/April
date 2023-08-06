using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    int i;
    public void SelectLevel(int value)
    {
        i = 0;
        LevelNumber.GetInt(i);
        Debug.Log("Level0 버튼 선택");
         PlayerPrefs.SetInt("GameLevel", (int)value);
        SceneManager.LoadScene("MapItemSelect");
        //맵 Scene으로 바뀌는 코드 
    }
}
