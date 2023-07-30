using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRabbit : MonoBehaviour
{
    public GameObject[] denInRabbits;
    public GameObject[] btnSelects;
    public GameObject[] readyRabbits;
    public int rabbitIndex; //denInRabbits 배열의 인덱스 관리 변수
    public int selectNum;
    public int rabbit3DNum;
    public static int i; //i를 해당 배열의 인덱스번호로 초기화시킴 , 인덱스번호를 담는 변수로써 사용

    public bool isBtnSelect;

    int FindRabbitIndex(GameObject targetRabbit)
    {
        for (int i = 0; i < denInRabbits.Length; i++)
        {
            if (denInRabbits[i] == targetRabbit)
            {
                rabbitIndex = i;
                return i;
                //Debug.Log("dd" + rabbitIndex);

            }

        }

        return -1;
    }
    public void DenInRabbit()
    {
        //den 안의 2D ui로 나타나는 버튼 컴포넌트를 포함하는 토끼 오브젝트에 OnClick에 연결되는 함수
        //denInRabbits 배열의 인덱스를 rabbitIndex로 관리가능하도록 추출하고 static 변수 i 에 rabbitIndex를 할당하여 아래 SelectBtnActive 함수에서 i를 활용할 수 있게 한다.
        Debug.Log(rabbitIndex);
     
    }

    public void PrintIndex()
    {
        Debug.Log("토끼번호 : " + i);
        Debug.Log("ready 씬으로 이동");
    }

   



}
