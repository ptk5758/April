using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrange : MonoBehaviour
{
    public GameObject[] ArrangeRandom0;
    public GameObject[] ArrangeRandom1;
    public GameObject[] ArrangeRandom2;
    public GameObject[] ArrangeRandom3;
    public GameObject ArrangeObject;
    public int ArrangeInt;

    void Awake()
    {
        RandomArrange();
    }

    public void RandomArrange()
    {
        Debug.Log("������ ���� Ȱ��ȭ ��");

        ArrangeInt = Random.Range(0, 4);
        Debug.Log(ArrangeInt + "���� �迭 ����");

        if (LevelNumber.selectLevel == 0)
        {
            ArrangeObject = ArrangeRandom0[ArrangeInt];
            ArrangeObject.gameObject.SetActive(true);
        }

        else if (LevelNumber.selectLevel == 1)
        {
            ArrangeObject = ArrangeRandom1[ArrangeInt];
            ArrangeObject.gameObject.SetActive(true);
        }


        else if (LevelNumber.selectLevel == 2)
        {
            ArrangeObject = ArrangeRandom2[ArrangeInt];
            ArrangeObject.gameObject.SetActive(true);
        }

        else if (LevelNumber.selectLevel == 3)
        {
            ArrangeObject = ArrangeRandom3[ArrangeInt];
            ArrangeObject.gameObject.SetActive(true);
        }
    }
}
