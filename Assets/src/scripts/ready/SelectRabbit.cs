using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRabbit : MonoBehaviour
{
    // SelectbtnActive���� rabbitIndex�� ����
    // Ư�� ��ǥ�� ������Ʈ ��Ȱ��ȭ > readyRabbits[rabbitIndex] ��° ������Ʈ Ȱ��ȭ

    public GameObject[] playableRabbit;
    public int playableRabbitIndex;
    bool isRabbitAcitve;

    private void Awake()
    {
        playableRabbitIndex = SelectbtnActive.rabbitIndex;

        isRabbitAcitve = false;
        //��Ȱ��ȭ �Լ� ȣ��
        //InactiveRabbit();
    }
    private void Start()
    {
        //�ش� ������Ʈ Ȱ��ȭ �Լ� ȣ��
        InactiveRabbit();
    }
    private void Update()
    {
        ActiveRabbit();
    }

    public void InactiveRabbit()
    {
        //�ݺ������� playableRabbit�� ������Ʈ �� ��Ȱ��ȭ��Ű��

        for(SelectbtnActive.rabbitIndex=0;SelectbtnActive.rabbitIndex<playableRabbit.Length;SelectbtnActive.rabbitIndex++)
        {
            
            playableRabbit[SelectbtnActive.rabbitIndex].SetActive(isRabbitAcitve);
            //Debug.Log(SelectbtnActive.rabbitIndex + "��° �䳢 ���� ");
        }

    }

    void ActiveRabbit()
    {
        //if������ �ش� �ε����� playableRabbit Ȱ��ȭ 
        Debug.Log( "den�� �ε��� : "+playableRabbitIndex);

        if(playableRabbitIndex==0)
        {
            isRabbitAcitve = true;
            playableRabbit[playableRabbitIndex].SetActive(isRabbitAcitve);
            //���� Active�� ������ �ȵǰ�����

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
