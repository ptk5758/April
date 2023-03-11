using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveItem : Item
{
    public override void SetType()
    {
        type = Item.Type.ACTIVE;
    }
}
