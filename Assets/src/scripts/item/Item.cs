using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour, IItem
{    
    private Rabbit rabbit;

    private void OnTriggerEnter(Collider other)
    {
        // Rabbit Item In Event
        if (other.gameObject.tag != "Player") return;
        rabbit = other.gameObject.GetComponent<Rabbit>();
        rabbit.NearItem = this;
    }

    private void OnTriggerExit(Collider other)
    {
        // Rabbit Item Exit Event
        if (other.gameObject.tag == "Player")
        {
            if (rabbit.NearItem != null)
                rabbit.NearItem = null;
        }
    }
    private void Awake()
    {        
    }
    public abstract void OnUseItem(Rabbit rabbit);

    private void OnDestroy()
    {
        Debug.Log(gameObject + "OnDestroy!");
    }    

}
