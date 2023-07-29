using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Level
{
    NORMAL, EXPERT, MASTER, KING
}

public class GameManager : MonoBehaviour
{
    
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<GameManager>();
                if (obj != null)
                    instance = obj;
            }
            return instance;

        }
        private set { instance = value; }
    }

    public static float playTime = 10f;
    public static int eggCount = 0;
    public static bool isPlaying = true;
    public static Level level = Level.NORMAL;

    public static void SetLevel(Level _level)
    {
        level = _level;
    }


    [SerializeField]
    EnemyController enemyController;

    [SerializeField]
    UIManager uiManager;

    private void Update()
    {
        playTime -= Time.deltaTime;
        if (playTime <= 0) GameEnd();

    }
    private void Start()
    {
        StartCoroutine(enemyController.SummonCoroutine()); // 여우 소환 코루틴 시작!
    }

    private void LateUpdate()
    {

        uiManager.Update();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void GameEnd()
    {
        GameStop();
        uiManager.OpenEndingBoard();
    }

    public static void GameStop()
    {
        Time.timeScale = 0;
    }

    public void CloseEndingBoard()
    {
        uiManager.CloseEndingBoard();
    }

}