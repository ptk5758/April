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

    [field:SerializeField]
    public float playTime { set; get; }
    public int eggCount { set; get; }


    [SerializeField]
    EnemyController enemyController;

    [SerializeField]
    UIManager uiManager;

    private void Update()
    {
        playTime -= Time.deltaTime;        
    }
    private void Start()
    {
        StartCoroutine(enemyController.SummonCoroutine()); // 여우 소환 코루틴 시작!
    }

    private void LateUpdate()
    {
        int m = (int)playTime / 60;
        int s = (int)playTime % 60;        
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
        InitializeToAwake();
    }

    public void InitializeToAwake() 
    {
        
    }
    
}