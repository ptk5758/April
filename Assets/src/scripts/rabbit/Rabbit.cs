using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface Rabbit
{
    public void OnHit(Enemy enemy);
    public Item NearItem { get; set; }
    public Transform GetTransform();
    public void DropEgg();
    public List<Egg> GetEggs();
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
}