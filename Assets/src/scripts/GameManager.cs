using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    [SerializeField]
    private ItemManager itemManager;

    [SerializeField]
    private EnemyController enemyController;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    GameObject panel;

    Animator anim;

    LevelManager levelManager;
    GameLevel gameLevel;

    private void OnDisable()
    {
        playTime = 10f;
        eggCount = 0;
    }

    private void Update()
    {
        playTime -= Time.deltaTime;
        if (playTime <= 0) GameEnd();

    }
    private void Start()
    {
        StartCoroutine(enemyController.SummonCoroutine()); //여우 소환 코루틴
    }

    private void LateUpdate()
    {

        uiManager.Update();
    }

    private void Awake()
    {
        anim = panel.GetComponent<Animator>();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        //DontDestroyOnLoad(gameObject);
        InitializeInstance();
        itemManager.InitializeItemManager();

    }
    private void InitializeInstance()
    {
        levelManager = new LevelManager();
        gameLevel = LevelManager.gameLevel;
    }

    public void GameEnd()
    {
        anim.SetBool("Level1", true);
        GameStop();
        uiManager.OpenEndingBoard();
    }

    public static void GameStop()
    {
        Time.timeScale = 0;
    }

    public void CloseEndingBoard() 
    {
        Time.timeScale = 1;
        uiManager.CloseEndingBoard();
    }
}