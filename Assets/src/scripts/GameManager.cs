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
    public Image[] imgPrefabs;
    public Item.Type itemType = Item.Type.None;
    private Item.Type lastItemType;
    public System.Action<Rabbit> itemHandler;
    public Rabbit player;
    [SerializeField]
    private Text eggCountUI;
    [SerializeField]
    private int eggCount = 0;

    // Play Time
    [field:SerializeField]
    public float playTime { private set; get; }
    public Text playTimeUI;

    public void UseItem()
    {
        itemHandler?.Invoke(player);
    }
    
    private void Update()
    {
        CheckItem();
        ActionPlayTime();
    }
    private void ActionPlayTime()
    {
        playTime -= Time.deltaTime;
        int m = (int) playTime / 60;
        int s = (int) playTime % 60;
        playTimeUI.text = $"TIME {m} : {s}";
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
        Init();
    }
    private void Init()
    {
        lastItemType = Item.Type.before;
        AddEggCount(0);
    }
    public void AddEggCount(int count)
    {
        eggCount += count;
        eggCountUI.text = $"Egg : {eggCount} °³";
    }

    private void CheckItem()
    {
        if (itemType != lastItemType)
        {
            if (itemType == Item.Type.before) return;
            if (itemArea.GetComponentsInChildren<Image>().Length > 0)
            {
                foreach (Image _img in itemArea.GetComponentsInChildren<Image>())
                {
                    Destroy(_img.gameObject);
                }
            }
            Image obj = Instantiate(imgPrefabs[(short)itemType], itemArea.transform);
            Button btn = obj.GetComponent<Button>();
            btn.onClick.AddListener(UseItem);
            lastItemType = itemType;
        }
    }
}
