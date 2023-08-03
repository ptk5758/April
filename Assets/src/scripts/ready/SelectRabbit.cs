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
        //isRabbitAcitve = true;
    }
    private void Update()
    {
        ActiveRabbit();
    }

    public void InactiveRabbit()
    {
        //�ݺ������� playableRabbit�� ������Ʈ �� ��Ȱ��ȭ��Ű��

        for(int i=0;i<playableRabbit.Length;i++)
        {
            
            playableRabbit[i].SetActive(isRabbitAcitve);
            Debug.Log(i + "��° �䳢 ���� ");
        }

    }

    void ActiveRabbit()
    {
        //if������ �ش� �ε����� playableRabbit Ȱ��ȭ 
        //Debug.Log( "den�� �ε��� : "+playableRabbitIndex);
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
