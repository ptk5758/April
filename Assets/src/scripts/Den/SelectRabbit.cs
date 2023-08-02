using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRabbit : MonoBehaviour
{
    // SelectbtnActive에서 rabbitIndex를 받음
    // 특정 좌표의 오브젝트 비활성화 > readyRabbits[rabbitIndex] 번째 오브젝트 활성화

    public GameObject[] playableRabbit;

    public Vector3 lastRabbitPosition = new Vector3(26f, -33f, 70f);
    public Transform lastRabbit;
    
    public void InactiveRabbit()
    {
        //특정 위치의(ready 화면에서 나타나는) 토끼 오브젝트 비활성화
        //이걸 겜매니저에 넣고 각 함수를 btnSelect에 연결

        //lastRabbit = 

        if(SelectbtnActive.rabbitIndex==0)
        {

        }


    }

    

    





}
