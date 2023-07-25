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
        if (Rabbit.instance != null && Rabbit.instance != this) Destroy(gameObject);
        else Rabbit.instance = this;        
        InitializeToAwak();
    }
    private void InitializeToAwak() 
    {
        SpawnPoint = transform.position;
        speed = 10;
        eggInventory = new List<Egg>();
        rabbitMoveMent = new RabbitMoveMent(this.gameObject);
        itemHandler = new RabbitItemHandler(this.gameObject);
    }
    private void Update()
    {
        CalculateSpeed();
    }    
    private void CalculateSpeed() 
    {        
        RabbitMoveMent.speed = this.speed;
    }

    private void FixedUpdate()
    {
        rabbitMoveMent.Moving();
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
        item.UseItem();
        Rabbit.activeItem = null;
    }
}
