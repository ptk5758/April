using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : EnemyImple
{
    public System.Action rangeHandle;
    protected override void Awake()
    {
        base.Awake();
        rangeHandle += OnRangeEnter;
    }

    public void OnRangeEnter()
    {
        isMove = true;
        Debug.Log("Enter!!!!");
    }
    
}
