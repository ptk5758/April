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
    public void OnHit(Enemy enemy);
    public void DropEgg();
    public Transform GetTransform();
    public Item NearItem { get; set; }
    public List<Egg> GetEggs();
    
    
}