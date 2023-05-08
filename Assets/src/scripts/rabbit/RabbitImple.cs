using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RabbitImple : MonoBehaviour, Rabbit
{

    [Header("Favorite Variable")]
    private GameManager gameManager;
    public float speed { get; set; } // 스피드 스텟 이거로 속도 조정함
    private float _speed; // 실제로 적용돼는 스피드

    [field:SerializeField] public Vector3 SpawnPoint { get; set; } // 토끼의 리스폰 장소
    [field:SerializeField] public ItemDefault detectItem { get; set; }
    [field:SerializeField] public ItemDefault currentItem { get; set; }

    public List<Egg> eggInventory { get; set; }

    /// <summary>
    ///  아이템 헨들러
    /// </summary>
    public ItemHandler itemHandler;


    private void Awake()
    {
        if (Rabbit.instance != null && Rabbit.instance != this) Destroy(gameObject);
        else Rabbit.instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeToAwak();
    }
    private void InitializeToAwak() 
    {
        gameManager = GameManager.Instance;
        SpawnPoint = transform.position;
        speed = 10; // 기본 스피드
        eggInventory = new List<Egg>();
        itemHandler = new ItemHandler(gameObject);

    }
    private void Update()
    {
        CalculateSpeed();
    }    
    private void CalculateSpeed() 
    {
        _speed = speed;
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

    public void OnHit(Fox fox)
    {
        Spawn();
    }

    public void Spawn()
    {
        gameObject.transform.position = SpawnPoint;
    }

    public Transform GetTransform() {
        return this.transform;
    }

    public void PickUpItem() {
        if (detectItem == null) return;
        PickUpItemAfter();
        switch (currentItem.GetItemType())
        {
            case ItemType.EGG:
                PickUpEgg();
                break;
            case ItemType.ITEM:
                Debug.Log("아이템임");
                break;
        }
    }
    public void PickUpItemAfter()
    {
        currentItem = detectItem;
        detectItem.gameObject.SetActive(false);
        detectItem = null;
    }

    public void PickUpEgg()
    {
        Debug.Log("달걀을 줍는 함수.");
        if(IsPickUpEgg()) {
            AddEggInventory();
        } else {
            Debug.Log("달걀을 주울수 가 없습");
        }
    }
    // 달걀 인벤토리에 계란을 넣는 함수
    private void AddEggInventory()
    {
        eggInventory.Add((Egg) currentItem);        
        currentItem = null;
        // Debug.Log("현재 소지중인 Egg Count : " + eggInventory.Count);
    }


    /// <summary>
    /// 달걀을 들수 있는지 없는지 체크
    /// </summary>    
    private bool IsPickUpEgg()
    {
        return true;
    }
    
    


    
    
}
