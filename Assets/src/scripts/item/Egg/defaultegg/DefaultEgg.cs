using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEgg : Egg
{
    public override void OnUseItem(Rabbit rabbit)
    {
        rabbit.AddEgg(this);
        Destroy(gameObject);        
    }
}