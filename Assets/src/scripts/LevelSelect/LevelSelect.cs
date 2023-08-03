using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    int i;

    public void Level0Select() //Level0이 선택됐을 때
    {
        i = 0;
        LevelNumber.GetInt(i);
        Debug.Log("Level0 버튼 선택");
        PlayerPrefs.SetInt("GameLevel", (int)Level.NORMAL);
        //Level.NORMAL의 int 값은 0이니까 0을 PlayerPrefs가 가지고 있음
        SceneManager.LoadScene("MapItemSelect");
        //맵 Scene으로 바뀌는 코드
    }

    public void Level1Select() //Level1이 선택됐을 때
    {
        i = 1;
        LevelNumber.GetInt(i);
        Debug.Log("Level1 버튼 선택");
        PlayerPrefs.SetInt("GameLevel", (int)Level.EXPERT);
        SceneManager.LoadScene("MapItemSelect");
        //맵 Scene으로 바뀌는 코드
    }

    public void Level2Select() //Level2이 선택됐을 때
    {
        i = 2;
        LevelNumber.GetInt(i);
        Debug.Log("Level2 버튼 선택");
        PlayerPrefs.SetInt("GameLevel", (int)Level.MASTER);
        SceneManager.LoadScene("MapItemSelect");
        //맵 Scene으로 바뀌는 코드
    }

    public void Level3Select() //Level3이 선택됐을 때
    {
        i = 3;
        LevelNumber.GetInt(i);
        Debug.Log("Level3 버튼 선택");
        PlayerPrefs.SetInt("GameLevel", (int)Level.KING);
        SceneManager.LoadScene("MapItemSelect");
        //맵 Scene으로 바뀌는 코드
    }
}
