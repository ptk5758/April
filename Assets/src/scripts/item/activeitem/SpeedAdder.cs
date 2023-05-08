using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAdder : ActiveItem
{
    Rabbit rabbit;
    public override void UseItem()
    {
        // Debug.Log("¼Óµµ°¡ »¡¶óÁü;;");
        rabbit = Rabbit.Instance;
        // StartCoroutine(SpeedUp());
    }
    /*
    IEnumerator SpeedUp()
    {
        rabbit.speed += 10;
        yield return new WaitForSeconds(5f);
        rabbit.speed -= 10;
    }
    */

}
