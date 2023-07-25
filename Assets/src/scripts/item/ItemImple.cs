using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDefault : MonoBehaviour, Item
{
    [SerializeField] private ItemType type;
    private void InitializeType()
    {
        switch (this.GetType().Name)
        {
            case "EggDefault":
                type = ItemType.EGG;
                break;
            default :
                type = ItemType.ITEM;
                break;
        }
    }
    public ItemType GetItemType()
    {
        return type;
    }

    private void Awake()
    {
        InitializeType();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        OnRabbitEnter(other.gameObject.GetComponent<Rabbit>());
    }

    private void OnRabbitEnter(Rabbit rabbit)
    {
        UIManager.isPickUP = true;
        RabbitItemHandler rabbitItemHandler = rabbit.itemHandler;        
        rabbitItemHandler.SetDetectItem(this);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        OnRabbitExit(other.gameObject.GetComponent<Rabbit>());
    }
    private void OnRabbitExit(Rabbit rabbit)
    {
        UIManager.isPickUP = false;
        RabbitItemHandler rabbitItemHandler = rabbit.itemHandler;
        rabbitItemHandler.SetDetectItem(null);
    }

}
