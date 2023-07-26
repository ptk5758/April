using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface Rabbit
{
    public static Rabbit instance;
    public static Rabbit Instance
    {
        get //값을 return해줌
        {
            if (instance == null)
            {
                var obj = GameObject.FindObjectOfType<RabbitImple>();
                if (obj != null)
                    instance = obj;
                //먹은 Egg, Item을 instance로 설정하면서 RabbitImple의 Awake에서
                //먹은 Object를 삭제하기 위해서 instance에 obj를 넣어줌
            }
            return instance;
        }
        private set { instance = value; } //instance값을 value로
    }
    public static Item activeItem { get; set; }
    public RabbitItemHandler itemHandler { get; set; }
    public void PickUpItem();

    /* 
     위에는 리팩토링 한 코드들
    
    밑에는 옛날에 짠 코드
     */

    public static bool isPickUpItem = false;
    public Transform GetTransform();
    public float speed { get; set; }
    public List<Egg> eggInventory { get; set; }
    public bool IsPickUpEgg();
    public void AddEggInventory(Egg egg);
    public void Spawn();
    
}