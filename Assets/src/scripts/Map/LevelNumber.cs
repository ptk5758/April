using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNumber
{
    public static int selectLevel; //���õ� ���̵��� ������

    public static void GetInt(int i) //LevelSelect Script�κ��� ����(������ ���̵�)�� �޾ƿ�
    {
        selectLevel = i;
    }

    public void SendLevel()
    {
        GameManager.SetLevel(selectLevel);
    }
}
