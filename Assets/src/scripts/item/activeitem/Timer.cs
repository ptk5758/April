using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : ActiveItem
{
    public int time;
    public override void UseItem()
    {
        GameManager.playTime += time;
    }
}
