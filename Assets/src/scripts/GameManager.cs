using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



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

    [SerializeField]
    private ItemManager itemManager;

    [SerializeField]
    private EnemyController enemyController;

    [SerializeField]
    private UIManager uiManager;

    private LevelManager levelManager;

    private void Update()
    {
        playTime -= Time.deltaTime;
        if (playTime <= 0) GameEnd();

    }
    private void Start()
    {
        StartCoroutine(enemyController.SummonCoroutine()); // ???? ???? ?????? ????!
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
        InitializeInstance();
        itemManager.InitializeItemManager();

    }
    private void InitializeInstance()
    {
        levelManager = new LevelManager();
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