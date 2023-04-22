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
    public int eggCount { set; get; }

    [Header("Favorite Variable")]
    public UIManager uiManager;

    private Item item;

    private void Update()
    {
        playTime -= Time.deltaTime;
    }

    private void LateUpdate() // Update FiexdUpdate after this Method call
    {
        int m = (int)playTime / 60;
        int s = (int)playTime % 60;
        uiManager.SetUIText(UIManager.Type.PLAY_TIME, $"TIME {m} : {s}");
        uiManager.SetUIText(UIManager.Type.EGG_COUNT, $"EGG : {eggCount}");
        uiManager.SetAbledToActiveItemButton(item != null);
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

    public void HandleItemPickUp(bool status)
    {
        uiManager.SetAbleToPickUpButton(status);
    }
    public void SetActiveItem(Item item)
    {
        this.item = item;
        // uiManager.SetAbledToActiveItemButton();
    }
}
