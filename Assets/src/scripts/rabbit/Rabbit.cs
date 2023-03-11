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
    public float speed = 1; // 토끼의 속도


    [field:SerializeField]
    public Item NearItem { get; set; } // 토끼가 가지고 있는함수
    private Item lastNearItem = null; // 토끼가 마지막으로 가지고 있던함수
    [field:SerializeField]
    public Item Item { get; set; } // 실제로 가지고있는 아이템
    public List<Egg> carryEgg;


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
        gameManager = GameManager.Instance;
        carryEgg = new List<Egg>();
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
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
        // transform.position += new Vector3(h, 0, v).normalized * Time.deltaTime * _speed;
        transform.position += new Vector3(h, 0, v).normalized * Time.deltaTime * speed;
    }

    public void PickUpItem() // 아이템을 줍는함수
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
    }
    
}
