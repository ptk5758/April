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
    //    //den ���� 2D ui�� ��Ÿ���� ��ư ������Ʈ�� �����ϴ� �䳢 ������Ʈ�� ����Ǵ� �Լ�
    //    //denInRabbits �迭�� �ε����� rabbitIndex�� ���������ϵ��� �����ϰ� static ���� i �� rabbitIndex�� �Ҵ��Ͽ� �Ʒ� SelectBtnActive �Լ����� i�� Ȱ���� �� �ְ� �Ѵ�.
    //    Debug.Log(i);

    //}

    //public void PrintIndex()
    //{
    //    Debug.Log("�䳢��ȣ : " + i);
    //}
}
