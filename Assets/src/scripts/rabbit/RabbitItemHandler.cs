using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitItemHandler
{
    GameObject current;
    Item detectItem;    
    public RabbitItemHandler(GameObject gameObject)
    {
        current = gameObject;
    }
    public void SetDetectItem(Item item) {
        detectItem = item;
    }
    public void PickUpItem()
    {
        if (detectItem == null) return;
        
        switch (detectItem.GetItemType())
        {
            case ItemType.EGG:                
                PickUpEgg();
                break;
            case ItemType.ITEM:
                PickUpActiveItem();
                break;
        }

        DetectItemDisable();
    }
    private void DetectItemDisable()
    {
        ItemDefault item = (ItemDefault) detectItem;
        item.gameObject.SetActive(false);
        detectItem = null;
    }


    private void PickUpEgg()
    {        
        Rabbit rabbit = current.GetComponent<Rabbit>();
        if (rabbit.IsPickUpEgg())
        {
            rabbit.AddEggInventory((Egg) detectItem);
        }
        else
        {
            Debug.Log("달걀을 주울수 가 없습");
        }
    }

    private void PickUpActiveItem()
    {
        Rabbit rabbit = current.GetComponent<Rabbit>();
    }

}
