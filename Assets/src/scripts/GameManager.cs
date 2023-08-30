using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



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

    public static float playTime = 120f; // 여기 하드코딩
    public static int eggCount = 0;
    public static bool isPlay = true;

    [SerializeField]
    private ItemManager itemManager;

    [SerializeField]
    private EnemyController enemyController;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    GameObject panel;

    Animator anim;

    [SerializeField]
    private GameObject systemPanel;
    public bool isSystemPanel;

    LevelManager levelManager;
    GameLevel gameLevel;

    private void OnDisable()
    {
        playTime = 120f; // 여기 하드코딩
        eggCount = 0;
        isPlay = true;
    }
    private void OnEnable()
    {
    }

    private void Update()
    {
        playTime -= Time.deltaTime;
        if (playTime <= 0) GameEnd();
        if (Input.GetKeyDown(KeyCode.Escape)) isSystemPanel = !isSystemPanel;
    }
    private void Start()
    {
        StartCoroutine(enemyController.SummonCoroutine()); //여우 소환 코루틴
    }

    private void LateUpdate()
    {
        if (isPlay) { 
            if (isSystemPanel) OpenSystemPanel();
            else CloseSystemPanel();
        }
        uiManager.Update();
    }

    private void OpenSystemPanel()
    {
        GameStop();
        systemPanel.SetActive(true);
    }
    private void CloseSystemPanel()
    {
        GameResume();
        systemPanel.SetActive(false);
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
        isPlay = false;
        anim.SetBool("Level1", true);
        GameStop();
        uiManager.OpenEndingBoard();
    }

    public static void GameStop()
    {
        Time.timeScale = 0;
    }

    public static void GameResume() {
        Time.timeScale = 1;
    }

    public void CloseEndingBoard() 
    {
        Time.timeScale = 1;
        uiManager.CloseEndingBoard();
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void GoTitle()
    {
        SceneManager.LoadScene("Ready");
    }
}