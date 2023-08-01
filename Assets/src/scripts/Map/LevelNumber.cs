using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNumber
{
    public static int selectLevel; //선택된 난이도가 몇인지

    public static void GetInt(int i) //LevelSelect Script로부터 숫자(선택한 난이도)를 받아옴
    {
        selectLevel = i;
    }

    public void SendLevel()
    {
        GameManager.SetLevel(selectLevel);
    }
}
