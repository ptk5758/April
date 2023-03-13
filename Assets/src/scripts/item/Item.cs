using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour, IItem
{
    public enum Type { 
        EGG,
        ACTIVE,
        PASSIVE
    }
    /**
     * private
     * */
    private Rabbit rabbit;
    public Type type;
    public abstract void SetType(); // Awake call to this method
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
    public abstract void OnUseItem(Rabbit rabbit); // extend the using item

    private void Awake()
    {
        SetType(); // Item Type Set
    }

    private void OnDestroy() // object destroy after call
    {
        // Debug.Log(gameObject + "OnDestroy!");
    }    

}
