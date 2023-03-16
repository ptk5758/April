using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : EnemyImple
{
    Collider range;
    protected override void Awake()
    {
        base.Awake();
        range = gameObject.GetComponentInChildren<SphereCollider>();                
    }
    
}
