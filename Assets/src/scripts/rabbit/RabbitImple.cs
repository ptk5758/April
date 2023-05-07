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
    [field:SerializeField] public ItemDefault DetectItem { get; set; }
    [field:SerializeField] public ItemDefault CurrentItem { get; set; }


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
        speed = 10; // 기본 스피드

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
        if (DetectItem == null) return;
        PickUpItemAfter();
    }
    
    public void PickUpItemAfter()
    {
        CurrentItem = DetectItem;
        DetectItem.gameObject.SetActive(false);
        DetectItem = null;
    }
    
    
}
