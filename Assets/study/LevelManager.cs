using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLevel
{
    NORMAL, EXPERT, MASTER
}
public class LevelManager : MonoBehaviour
{
    public GameLevel level;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (level)
            {
                case GameLevel.MASTER:
                    Debug.Log("������ 1�� ����");
                    break;
                case GameLevel.EXPERT:
                    Debug.Log("������ 3�� ����");
                    break;                
                case GameLevel.NORMAL:
                    Debug.Log("������ 5�� ����");
                    break;
                default:
                    Debug.Log("�߸��� ���̵��Դϴ�.");
                    break;

            }
        }
    }
}
