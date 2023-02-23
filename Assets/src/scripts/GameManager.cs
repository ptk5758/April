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
        set { instance = value; }
    }

    public GameObject itemArea;
    public Image[] imgPrefabs;
    public Item.Type itemType = Item.Type.None;
    private Item.Type lastItemType;
    public System.Action itemAction;
    public string test;
    public void UseItem()
    {
        itemAction?.Invoke();
    }
    private void Update()
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
            Image obj = Instantiate(imgPrefabs[(short) itemType], itemArea.transform);
            Button btn = obj.GetComponent<Button>();
            btn.onClick.AddListener(UseItem);
            lastItemType = itemType;
        }

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
    }
}
