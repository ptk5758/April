using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get; private set; }

    public GameObject itemArea;
    public Image[] imgPrefabs;
    public Item.Type itemType = Item.Type.None;
    private Item.Type lastItemType;
    // public System.Action<int> itemAreaFunc;
    private void Update()
    {
        if (itemType != lastItemType)
        {
            Image obj = Instantiate(imgPrefabs[(short) itemType], itemArea.transform);
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
