using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RabbitImple : MonoBehaviour, Rabbit
{

    [Header("Favorite Variable")]
    private GameManager gameManager;
    public float speed { get; set; } // 스피드 스텟 이거로 속도 조정함

    [field:SerializeField] public Vector3 SpawnPoint { get; set; } // 토끼의 리스폰 장소
    [field:SerializeField] public ItemDefault currentItem { get; set; }

    /// <summary>
    /// 달걀 인벤토리
    /// </summary>
    public List<Egg> eggInventory { get; set; }    

    /// <summary>
    ///  아이템 관련 헨들러 인스턴스
    /// </summary>
    public ItemHandler itemHandler { get; set; }

    /* 2023-07-02 */
    private RabbitMoveMent rabbitMoveMent;

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
        rabbitMoveMent = new RabbitMoveMent(this.gameObject);

    }
    private void Update()
    {
        CalculateSpeed();
    }    
    private void CalculateSpeed() 
    {        
        RabbitMoveMent.speed = this.speed;
    }

    private void Start()
    {
        gameManager.HandleItemPickUp(false);
    }

    private void FixedUpdate()
    {
        rabbitMoveMent.Moving();
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
        // Debug.Log("Pick Up Item!!!");
        itemHandler.PickUpItem();
    }

    // 달걀 인벤토리에 계란을 넣는 함수
    public void AddEggInventory(Egg egg)
    {
        eggInventory.Add(egg);                
        // Debug.Log("현재 소지중인 Egg Count : " + eggInventory.Count);
    }

    /// <summary>
    /// 달걀을 들수 있는지 없는지 체크
    /// </summary>    
    public bool IsPickUpEgg()
    {
        return true;
    }


    /// <summary>
    /// 가지고있는 아이템을 사용하는 함수이다.
    /// </summary>
    public void DoUseItem()
    {
        if (!IsUseItem()) return;
        ActiveItem item = (ActiveItem) currentItem;
        item.UseItem();
    }

    private bool IsUseItem()
    {
        if (currentItem == null) return false;
        return true;
    }
    
    


    
    
}
