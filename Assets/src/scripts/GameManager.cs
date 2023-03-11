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
    public Rabbit player;

    [field:SerializeField]
    public float playTime { private set; get; }

    [Header("Favorite Variable")]
    public UIManager uiManager;

    private void Update()
    {
        playTime -= Time.deltaTime;
    }

    private void LateUpdate() // 모든 Update 구문 호출후 호출됨
    {
        int m = (int)playTime / 60;
        int s = (int)playTime % 60;
        uiManager.SetUIText(UIManager.Type.PLAY_TIME, $"TIME {m} : {s}");
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
}
