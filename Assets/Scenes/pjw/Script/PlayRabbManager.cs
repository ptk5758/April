using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayRabbManager : MonoBehaviour
{

    DenInRabb1 denInRabbit;
    public Text playRabbit;

    //Den�� �ν����� ���� �޾ƿ� >Ready�� Rabbinfo�� ����(�� �޾ƿͼ� ������ ���°� ����)

    //DenInRabb���� rabbitSpecies �޾ƿ���
    //�޾ƿ� �Ÿ� ui����

    private void Awake()
    {
        denInRabbit = GameObject.Find("01Rabb").GetComponent<DenInRabb1>();
    }

    public void Update()
    {
        playRabbit.text = denInRabbit.rabbitNum.ToString();
      
        
    }


}
