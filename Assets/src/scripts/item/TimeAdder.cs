using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdder : Item
{
    public override void OnUseItem(Rabbit rabbit)
    {
        Debug.Log(rabbit);
    }
}
