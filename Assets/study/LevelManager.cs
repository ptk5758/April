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
                    Debug.Log("아이템 1개 생성");
                    break;
                case GameLevel.EXPERT:
                    Debug.Log("아이템 3개 생성");
                    break;                
                case GameLevel.NORMAL:
                    Debug.Log("아이템 5개 생성");
                    break;
                default:
                    Debug.Log("잘못된 난이도입니다.");
                    break;

            }
        }
    }
}
