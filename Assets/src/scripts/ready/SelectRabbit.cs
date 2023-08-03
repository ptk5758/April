using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRabbit : MonoBehaviour
{
    // SelectbtnActive에서 rabbitIndex를 받음
    // 특정 좌표의 오브젝트 비활성화 > readyRabbits[rabbitIndex] 번째 오브젝트 활성화

    public GameObject[] playableRabbit;
    public int playableRabbitIndex;
    bool isRabbitAcitve;

    private void Awake()
    {
        playableRabbitIndex = SelectbtnActive.rabbitIndex;

        isRabbitAcitve = false;
        //비활성화 함수 호출
        //InactiveRabbit();
    }
    private void Start()
    {
        //해당 오브젝트 활성화 함수 호출
        InactiveRabbit();
    }
    private void Update()
    {
        ActiveRabbit();
    }

    public void InactiveRabbit()
    {
        //반복문으로 playableRabbit의 오브젝트 다 비활성화시키기

        for(SelectbtnActive.rabbitIndex=0;SelectbtnActive.rabbitIndex<playableRabbit.Length;SelectbtnActive.rabbitIndex++)
        {
            
            playableRabbit[SelectbtnActive.rabbitIndex].SetActive(isRabbitAcitve);
            //Debug.Log(SelectbtnActive.rabbitIndex + "번째 토끼 삭제 ");
        }

    }

    void ActiveRabbit()
    {
        //if문으로 해당 인덱스의 playableRabbit 활성화 
        Debug.Log( "den의 인덱스 : "+playableRabbitIndex);

        if(playableRabbitIndex==0)
        {
            isRabbitAcitve = true;
            playableRabbit[playableRabbitIndex].SetActive(isRabbitAcitve);
            //위의 Active가 실행이 안되고있음

        }

        if (playableRabbitIndex == 1)
        {
            playableRabbit[playableRabbitIndex].SetActive(true);
        }

        if (playableRabbitIndex == 2)
        {
            playableRabbit[playableRabbitIndex].SetActive(true);
        }

        if (playableRabbitIndex == 3)
        {
            playableRabbit[playableRabbitIndex].SetActive(true);
        }

    }









}
