using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEgg : Egg
{
    public override void OnUseItem(Rabbit rabbit)
    {
        // 토끼한태 달걀넣어줌
        rabbit.AddEgg(this);
        Destroy(gameObject);        
    }
}