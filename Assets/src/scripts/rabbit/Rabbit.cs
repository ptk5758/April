using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface Rabbit
{
    public static Rabbit instance;
    public static Rabbit Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = GameObject.FindObjectOfType<RabbitImple>();
                if (obj != null)
                    instance = obj;
            }
            return instance;
        }
        private set { instance = value; }
    }

    public static bool isPickUpItem = false;
    public Transform GetTransform();    

    /// <summary>
    /// 토끼 스피드
    /// </summary>
    public float speed { get; set; }
    /// <summary>
    /// 토끼가 가지고있는 Egg 리스트
    /// </summary>
    public List<Egg> eggInventory { get; set; }

    /// <summary>
    /// 달걀을 들수 있는지 없는지 체크
    /// </summary>    
    public bool IsPickUpEgg();

    /// <summary>
    /// 달걀 인벤토리에 계란을 넣는 함수
    /// </summary>
    public void AddEggInventory(Egg egg);

    public void Spawn();


}