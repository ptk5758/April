using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDefault : MonoBehaviour, Item
{
    [SerializeField] private ItemType type;
    private void InitType()
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
    private void Awake()
    {
        InitType();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        Rabbit rabbit = other.GetComponent<Rabbit>();
        rabbit.itemHandler.SetDetectItem(this);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        Rabbit rabbit = other.GetComponent<Rabbit>();
        rabbit.itemHandler.SetDetectItem(null);
    }
    public ItemType GetItemType()
    {
        return type;
    }
}
