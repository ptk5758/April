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

    public float speed = 1;
    public float eggWeight = 0.5f;
    public List<Egg> eggs;
    private float _speed;
    private Vector3 spawnPostion;


    // near Item
    [field:SerializeField]
    public Item NearItem { get; set; }
    private Item lastNearItem = null;
    private GameManager gameManager;


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
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        _speed = speed - eggs.Count * eggWeight;
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
    public void AddEgg(Egg egg)
    {        
        eggs.Add(egg);
    }

    public void OnHit(Enemy enemy)
    {
        Debug.Log("On Hit");
        transform.position = spawnPostion;
    }

    public void PickUpEgg()
    { 

    }
    
}
