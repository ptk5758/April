using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNumber
{
    public static int selectLevel; //���õ� ���̵��� ������

    void Start()
    {
        
    }

    
    void Update()
    {
      
    }

    public static void GetInt(int i) //LevelSelect Script�κ��� ����(������ ���̵�)�� �޾ƿ�
    {
        selectLevel = i;
    }

  
}
