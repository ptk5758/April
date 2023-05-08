using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    EGG, 
    ITEM
}
public interface Item {

    /// <summary>
    /// EGG, ITEM
    /// </summary>    
    public ItemType GetItemType();
}