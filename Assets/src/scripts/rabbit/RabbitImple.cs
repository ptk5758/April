using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RabbitImple : MonoBehaviour, Rabbit
{   
    public float speed { get; set; }
    public Vector3 SpawnPoint { get; set; }
    public List<Egg> eggInventory { get; set; }
    public RabbitItemHandler itemHandler { get; set; }
    private RabbitMoveMent rabbitMoveMent;

    private void Awake()
    {
        // if (Rabbit.instance != null && Rabbit.instance != this) Destroy(gameObject); // -> gameObject�� �� ����ϴ°���?
        //Destroy : ���� ������Ʈ ���� 
        //Rabbit���� instance�� obj�� �־���� ������ null�� �ƴϸ��� ������ �����Ŵϱ� �ش� Object�� ������Ŵ
        // -> ���� �� ���־��ϱ�(��Ȱ��ȭ) ������
        // else Rabbit.instance = this;  
        //**** this�� ����Ű�°� ���� �𸣰��� **** -> ��ũ��Ʈ ��ü�� ����ϴ� �ǰ�?
        InitializeToAwak();
    }
    private void InitializeToAwak() 
    {
        SpawnPoint = transform.position;
        speed = 10;
        eggInventory = new List<Egg>();
        rabbitMoveMent = new RabbitMoveMent(this.gameObject); 
        //RabbitMoveMent�� �ش� gameObject�� ���� -> ������ ���� ���⼭ ��� ������ ������ ���� rabbitMoveMent�� ����?
        itemHandler = new RabbitItemHandler(this.gameObject);
    }
    private void Update()
    {
        rabbitMoveMent.Update();
        CalculateSpeed();
    }    
    private void CalculateSpeed() 
    {        
        RabbitMoveMent.speed = this.speed; //�� ��ũ��Ʈ�� �ִ� speed = 10�� RabbitMoveMent�� speed��
    }

    private void FixedUpdate()
    {
       rabbitMoveMent.Moving();
        //rabbitMoveMent�� new RabbitMoveMent�� ����������ϱ� Moving() Ŭ������ ��� ����?
        //new RabbitMoveMent(this.gameObject);�� ���ؼ� gameObject�� ������ �ش� Object�� current�� �����ϰ�
        //rabbitMoveMent�� �̷� �������� ����ִ�? ��ü�ϱ� Moving() Ŭ������ ��� �����ϴ�?
    }

    public void Spawn()
    {
        gameObject.transform.position = SpawnPoint;
    }

    public Transform GetTransform() {
        return this.transform;
    }

    public void AddEggInventory(Egg egg)
    {
        eggInventory.Add(egg);                
    }
    public bool IsPickUpEgg()
    {
        return true;
    }

    public void PickUpItem()
    {
        itemHandler.PickUpItem();
    }

    public void UseItem()
    {
        ActiveItem item = Rabbit.activeItem as ActiveItem;
        item.UseItem(); //SpeedAdder�� �ִ� UseItemŬ������ ���?
        Rabbit.activeItem = null; //�������� ��������ϱ� activeItem ���� null�� �ٲ���
    }
}
