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

    public GameObject itemArea;
    private Rabbit rabbit;

    [field:SerializeField]
    public float playTime { set; get; }
    public int eggCount { set; get; }

    public UIManager uiManager;

    [SerializeField]
    EnemyController enemyController;

    float coolTime = 10f;

    private void Update()
    {
        playTime -= Time.deltaTime;        
    }
    private void Start()
    {
        StartCoroutine(enemyController.SummonCoroutine()); // 여우 소환 코루틴 시작!
    }

    private void LateUpdate() // Update FiexdUpdate after this Method call
    {
        int m = (int)playTime / 60;
        int s = (int)playTime % 60;
        uiManager.SetUIText(UIManager.Type.PLAY_TIME, $"TIME {m} : {s}");
        uiManager.SetUIText(UIManager.Type.EGG_COUNT, $"EGG : {eggCount}");
        uiManager.SetAbleToPickUpButton(Rabbit.isPickUpItem);
        uiManager.activeItem.SetActive(rabbit.currentItem != null);
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
    private void InitializeToAwake()
    {
        rabbit = Rabbit.Instance;
    }

    public void HandleItemPickUp(bool status)
    {
        uiManager.SetAbleToPickUpButton(status);
    }   
    
}

[Serializable]
class EnemyController
{
    public EnemyManager enemyManager;
    public float coolTime;
    public void Summon()
    {
        enemyManager.SummonEnemey();
    }
    public IEnumerator SummonCoroutine()
    {
        while (true)
        {
            Summon();
            yield return new WaitForSeconds(coolTime);
        }
    }
}

