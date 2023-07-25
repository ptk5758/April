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

    public RabbitItemHandler itemHandler { get; set; }

    public static bool isPickUpItem = false;
    public Transform GetTransform();
    public float speed { get; set; }
    public List<Egg> eggInventory { get; set; }
    public bool IsPickUpEgg();
    public void AddEggInventory(Egg egg);
    public void Spawn();
}