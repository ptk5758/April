using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRabbit : MonoBehaviour
{
    public GameObject[] denInRabbits;
    public GameObject[] btnSelects;
    public GameObject[] readyRabbits;
    public int rabbitIndex; //denInRabbits �迭�� �ε��� ���� ����
    public int selectNum;
    public int rabbit3DNum;
    public static int i; //i�� �ش� �迭�� �ε�����ȣ�� �ʱ�ȭ��Ŵ , �ε�����ȣ�� ��� �����ν� ���

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
        //den ���� 2D ui�� ��Ÿ���� ��ư ������Ʈ�� �����ϴ� �䳢 ������Ʈ�� OnClick�� ����Ǵ� �Լ�
        //denInRabbits �迭�� �ε����� rabbitIndex�� ���������ϵ��� �����ϰ� static ���� i �� rabbitIndex�� �Ҵ��Ͽ� �Ʒ� SelectBtnActive �Լ����� i�� Ȱ���� �� �ְ� �Ѵ�.
        Debug.Log(rabbitIndex);
     
    }

    public void PrintIndex()
    {
        Debug.Log("�䳢��ȣ : " + i);
        Debug.Log("ready ������ �̵�");
    }

   



}
