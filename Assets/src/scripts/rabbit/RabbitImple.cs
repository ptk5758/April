using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RabbitImple : MonoBehaviour, Rabbit
{
    
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
    private List<Egg> carryEgg = new List<Egg>(); // Rabbit Carry Egg
    public float eggWeight; // egg weight 
    private float _speed; // Actual Applied Speed

    [field:SerializeField]
    public Vector3 SpawnPoint { get; set; } // Rabbit spawn Point    

    private void Awake()
    {
        if (Rabbit.instance != null && Rabbit.instance != this) Destroy(gameObject);
        else Rabbit.instance = this;
        DontDestroyOnLoad(gameObject);
        AwakeInit();
    }
    private void AwakeInit() 
    {
        gameManager = GameManager.Instance;
        SpawnPoint = transform.position;
    }
    private void Update()
    {
        CalculateSpeed();
        ItemHandler();
    }
    private void ItemHandler()
    {
        if (lastNearItem != NearItem)
        {
            lastNearItem = NearItem;
            gameManager.HandleItemPickUp(lastNearItem != null);
        }
    }
    private void CalculateSpeed() 
    {
        _speed = speed - eggWeight * carryEgg.Count;
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
        if (NearItem.type == Item.Type.EGG) PickUpEgg(NearItem);
    }

    private void PickUpEgg(Item item)
    {
        carryEgg.Add((Egg) item);
        NearItem = null;
        item.gameObject.SetActive(false);
    }

    public void OnHit(Fox fox)
    {
        Debug.Log("On Hit");
        Spawn();
    }

    public List<Egg> GetEggs()
    {
        return carryEgg;
    }

    public void DropEgg()
    {
        carryEgg.Clear();
    }

    public void Spawn()
    {
        gameObject.transform.position = SpawnPoint;
    }

    public Transform GetTransform() {
        return this.transform;
    }
    
    
}
