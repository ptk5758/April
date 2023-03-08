using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour, IItem
{    
    private GameManager gm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        Rabbit instance = Rabbit.Instance;
        instance.Item = this;   
        // gm.itemHandler += OnUseItem;
        // gm.itemType = this.type;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // gm.itemHandler -= OnUseItem;
            // gm.itemType = Type.None;
        }
    }
    private void Awake()
    {        
        this.gm = GameManager.Instance;
    }
    public abstract void OnUseItem(Rabbit rabbit);
    private void OnDestroy()
    {        
        gm.itemHandler -= OnUseItem;
    }    

}
