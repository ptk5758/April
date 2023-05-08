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
}
