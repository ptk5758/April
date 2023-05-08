using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DenInRabb1 : MonoBehaviour
{
    //public static GameObject[] rabbitSpecies;
    public int rabbitNum;
   
    public void SelectRabb()
    {
        //GameObject rabbitSpec = rabbitSpecies[rabbitNum];
        Debug.Log(rabbitNum);
        SceneManager.LoadScene("Ready");
    }

    //rabbitSpecies 토끼 종/ Den 내 토끼 식별하는 네
    //이걸 전역으로 줌 == 인스펙터로 안감
    //네 지난번엔 이 역할 하는 변수를 SelectRabb 매개변수로 줬는데
    //질문드렸을때 전역으로하면 안되나요?했더니 안될건없다고하심(맞말)
    //DenInRabb에서 시험삼아 5로 초기화 시 디버그로그에선 5로 출력
    //Ready 씬에서 플레이 시에는 전과 같이 0으로 표시됨()

    //각각 토끼가 인스펙터 값으로 초기화되어야함
    //int가 아니라 GameObj로 줘서 로그라인처럼 배열에 어쩌고할수는없나??
    //DeninRabb 인스펙터에서 옵젝배열에 각 토끼 할당? xx
    //클릭 > 각 옵젝의 인스펙터값(이하 a)을 뱉어내야함
    //wkrl자기참조 < 안됨~~무친

    //rabbitNum을 PlayRabb에서 씀
}
