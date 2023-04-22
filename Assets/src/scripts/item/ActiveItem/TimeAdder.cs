using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdder : ActiveItem
{
    int TIME_VALUE = 30;
    public override void OnUseItem()
    {
        // Debug.Log("이거는 타임 추가 아이템이니까 여기에 코드를 넣어주세요");
        Debug.Log("시간 추가!");
        GameManager gameManager = GameManager.Instance;
        gameManager.playTime += TIME_VALUE;
        gameManager.UseItemListener();
    }
}
