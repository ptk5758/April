using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayRabbManager : MonoBehaviour
{

    DenInRabb1 denInRabbit;
    public Text playRabbit;

    //Den의 인스펙터 값을 받아옴 >Ready의 Rabbinfo와 연결(값 받아와서 텍으로 띄우는게 먼저)

    //DenInRabb에서 rabbitSpecies 받아오기
    //받아온 거를 ui연결

    private void Awake()
    {
        denInRabbit = GameObject.Find("01Rabb").GetComponent<DenInRabb1>();
    }

    public void Update()
    {
        playRabbit.text = denInRabbit.rabbitNum.ToString();
      
        
    }


}
