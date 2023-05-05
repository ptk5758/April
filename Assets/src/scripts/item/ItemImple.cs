using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemImple : MonoBehaviour, Item
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
        Debug.Log("Trigger Enter!");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit");
    }
}
