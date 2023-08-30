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
        // if (Rabbit.instance != null && Rabbit.instance != this) Destroy(gameObject); // -> gameObject는 뭘 얘기하는거지?
        //Destroy : 게임 오브젝트 삭제 
        //Rabbit에서 instance에 obj를 넣어줬기 때문에 null이 아니면은 뭔가를 먹은거니까 해당 Object를 삭제시킴
        // -> 먹은 건 없애야하기(비활성화) 때문에
        // else Rabbit.instance = this;  
        //**** this가 가르키는게 뭔지 모르겠음 **** -> 스크립트 자체를 얘기하는 건가?
        InitializeToAwak();
    }
    private void InitializeToAwak() 
    {
        SpawnPoint = transform.position;
        speed = 10;
        eggInventory = new List<Egg>();
        rabbitMoveMent = new RabbitMoveMent(this.gameObject); 
        //RabbitMoveMent로 해당 gameObject를 보냄 -> 보내고 나서 저기서 모든 과정을 수행한 값을 rabbitMoveMent에 저장?
        itemHandler = new RabbitItemHandler(this.gameObject);
    }
    private void Update()
    {
        rabbitMoveMent.Update();
        CalculateSpeed();
    }    
    private void CalculateSpeed() 
    {        
        RabbitMoveMent.speed = this.speed; //이 스크립트에 있는 speed = 10을 RabbitMoveMent의 speed로
    }

    private void FixedUpdate()
    {
       rabbitMoveMent.Moving();
        //rabbitMoveMent이 new RabbitMoveMent로 만들어졌으니까 Moving() 클래스를 사용 가능?
        //new RabbitMoveMent(this.gameObject);를 통해서 gameObject를 보내서 해당 Object를 current로 설정하고
        //rabbitMoveMent는 이런 과정들을 담고있는? 객체니까 Moving() 클래스를 사용 가능하다?
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
        item.UseItem(); //SpeedAdder에 있는 UseItem클래스를 사용?
        Rabbit.activeItem = null; //아이템을 사용했으니까 activeItem 값을 null로 바꿔줌
    }
}
