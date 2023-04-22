using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAdder : ActiveItem
{
    Rabbit rabbit;
    int SPEED_UP_TIME = 5;
    public override void OnUseItem()
    {
        rabbit = Rabbit.Instance;
        Debug.Log("이속 증가!");
        StartCoroutine(DoRabbitSpeedUp());
        GameManager gameManager = GameManager.Instance;
        gameManager.UseItemListener();
    }
    IEnumerator DoRabbitSpeedUp()
    {
        rabbit.speed += 5;
        yield return new WaitForSeconds(SPEED_UP_TIME); // 5초 동안?
        rabbit.speed -= 5;
    }
}
