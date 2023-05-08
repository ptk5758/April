using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler
{
    GameObject current;
    Item detectItem;    
    public ItemHandler(GameObject gameObject)
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
                Debug.Log("��������");
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


    public void PickUpEgg()
    {        
        Rabbit rabbit = current.GetComponent<Rabbit>();
        if (rabbit.IsPickUpEgg())
        {
            rabbit.AddEggInventory((Egg) detectItem);
        }
        else
        {
            Debug.Log("�ް��� �ֿ�� �� ����");
        }
    }

}
