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
    public float speed = 1; // �䳢�� �ӵ�


    [field:SerializeField]
    public Item NearItem { get; set; } // �䳢�� ������ �ִ��Լ�
    private Item lastNearItem = null; // �䳢�� ���������� ������ �ִ��Լ�
    [field:SerializeField]
    public Item Item { get; set; } // ������ �������ִ� ������
    [SerializeField]
    private List<Egg> carryEgg; // ���� ����ִ� Egg
    public float eggWeight; // �ް��� ����
    private float _speed; // �� ����� ���ǵ�


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

    public void PickUpItem() // �������� �ݴ��Լ�
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

    public List<Egg> GetEgg()
    {
        return carryEgg;
    }
    
}
