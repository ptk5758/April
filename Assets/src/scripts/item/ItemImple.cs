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
    private void Awake()
    {
        InitializeType();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        Rabbit rabbit = other.GetComponent<Rabbit>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        Rabbit rabbit = other.GetComponent<Rabbit>();
    }
    public ItemType GetItemType()
    {
        return type;
    }
}
