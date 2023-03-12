using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PssiveItem : Item
{
    public override void SetType()
    {
        type = Item.Type.PASSIVE;
    }
}
