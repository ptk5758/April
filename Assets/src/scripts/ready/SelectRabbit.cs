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
        //isRabbitAcitve = true;
    }
    private void Update()
    {
        ActiveRabbit();
    }

    public void InactiveRabbit()
    {
        //반복문으로 playableRabbit의 오브젝트 다 비활성화시키기

        for(int i=0;i<playableRabbit.Length;i++)
        {
            
            playableRabbit[i].SetActive(isRabbitAcitve);
            Debug.Log(i + "번째 토끼 삭제 ");
        }

    }

    void ActiveRabbit()
    {
        //if문으로 해당 인덱스의 playableRabbit 활성화 
        //Debug.Log( "den의 인덱스 : "+playableRabbitIndex);
        //Debug.Log("ddd " + SelectbtnActive.rabbitIndex);
        isRabbitAcitve = true;

        if (SelectbtnActive.rabbitIndex==0)
        {
           
            playableRabbit[SelectbtnActive.rabbitIndex].SetActive(isRabbitAcitve);
            Debug.Log("sss" + SelectbtnActive.rabbitIndex);

        }

        if (SelectbtnActive.rabbitIndex == 1)
        {
            playableRabbit[SelectbtnActive.rabbitIndex].SetActive(true);
            Debug.Log("sss" + SelectbtnActive.rabbitIndex);
        }

        if (SelectbtnActive.rabbitIndex == 2)
        {
            playableRabbit[SelectbtnActive.rabbitIndex].SetActive(true);
            Debug.Log("sss" + SelectbtnActive.rabbitIndex);
        }

        if (SelectbtnActive.rabbitIndex == 3)
        {
            playableRabbit[SelectbtnActive.rabbitIndex].SetActive(true);
            Debug.Log("sss" + SelectbtnActive.rabbitIndex);
        }

    }









}
