using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAdder : ActiveItem
{
    Rabbit rabbit;
    public override void UseItem()
    {
        rabbit = Rabbit.Instance;        
        SpeedUp();
    }
    public void SpeedUp()
    {
        rabbit.speed += 10;
        Invoke("SpeedReset", 5f);
    }
    public void SpeedReset()
    {
        rabbit.speed -= 10;
    }
}
