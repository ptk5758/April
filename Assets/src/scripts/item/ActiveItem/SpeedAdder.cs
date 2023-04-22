using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAdder : ActiveItem
{
    public override void OnUseItem()
    {
        Debug.Log("이속 증가!");
    }
}
