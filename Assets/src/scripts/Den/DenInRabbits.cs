using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenInRabbits : SelectRabbit
{
    //private void Awake()
    //{
    //    rabbitIndex = FindRabbitIndex(gameObject);
    //}

    void Update()
    {
        //rabbitIndex = i;
        //rabbitIndex = FindRabbitIndex(targetRabbit);
    }

    int FindRabbitIndex(GameObject targetRabbit)
    {
        for (int i = 0; i < denInRabbits.Length; i++)
        {
            if (denInRabbits[i] == targetRabbit)
            {
                rabbitIndex = i;
                return i;
                Debug.Log("dd"+rabbitIndex);
                
            }
            
        }

        return -1;
    }

    //public void DenInRabbit()
    //{
    //    //den 안의 2D ui로 나타나는 버튼 컴포넌트를 포함하는 토끼 오브젝트에 연결되는 함수
    //    //denInRabbits 배열의 인덱스를 rabbitIndex로 관리가능하도록 추출하고 static 변수 i 에 rabbitIndex를 할당하여 아래 SelectBtnActive 함수에서 i를 활용할 수 있게 한다.
    //    Debug.Log(i);

    //}

    //public void PrintIndex()
    //{
    //    Debug.Log("토끼번호 : " + i);
    //}
}
