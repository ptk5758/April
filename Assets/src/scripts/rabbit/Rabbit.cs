using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rabbit : MonoBehaviour, IRabbit
{
    private static Rabbit instance;
    public static Rabbit Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<Rabbit>();
                if (obj != null)
                    instance = obj;                
            }
            return instance;
        }
        private set { instance = value; }
    }
    [Header("Favorite Variable")]
    private GameManager gameManager;

    [Header("Attribute Variable")]
    public float speed = 1; // Rabbit Move Speed


    [field:SerializeField]
    public Item NearItem { get; set; } // Rabbit detect to near item
    private Item lastNearItem = null;
    [field:SerializeField]
    public Item Item { get; set; } // Rabbit have item
    [SerializeField]
    private List<Egg> carryEgg; // Rabbit Carry Egg
    public float eggWeight; // egg weight 
    private float _speed; // Actual Applied Speed

    [field:SerializeField]
    public Vector3 spawnPoint { get; set; } // Rabbit spawn Point


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
        gameManager = GameManager.Instance;
        carryEgg = new List<Egg>();
        spawnPoint = transform.position;
    }
    private void Update()
    {
        _speed = speed - eggWeight * carryEgg.Count;
        if (lastNearItem != NearItem)
        {
            lastNearItem = NearItem;
            gameManager.HandleItemPickUp(lastNearItem != null);
        }
    }

    private void Start()
    {
        gameManager.HandleItemPickUp(false);
    }
    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(h, 0, v).normalized * Time.deltaTime * _speed;
    }

    public void PickUpItem() // pick up to near Item
    {
        if (NearItem == null) return;
        if (NearItem.type == Item.Type.EGG)
        {
            PickUpEgg(NearItem);
        }
    }

    private void PickUpEgg(Item item)
    {
        carryEgg.Add((Egg) item);
        NearItem = null;
        item.gameObject.SetActive(false);
    }

    public void OnHit(Enemy enemy)
    {
        Debug.Log("On Hit");
        Spawn();
    }

    public List<Egg> GetEgg()
    {
        return carryEgg;
    }

    public void Spawn()
    {
        gameObject.transform.position = spawnPoint;
    }
    
}
