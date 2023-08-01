using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public GameObject[] MapRandom;
    GameObject MapObject;
    int RandomInt;

    void Awake()
    {
        ActiveMap();
    }
    
    void Update()
    {
        //Update랑 Start에서 ActiveMap() 함수를 실행시키면 랜덤숫자를 두번 받아오는데 왜인지 모르겠음 -> 이유가 궁금
        //if (ActiveBool == true) 
        //{
        //    ActiveMap();
        //    ActiveBool = false; //맵이 Update로 인해서 계속 바뀌는 것을 방지?
        //    Debug.Log("중지");
        //}

    }

    public void ActiveMap() //랜덤 숫자를 받아서 그 숫자에 있는 배열의 Object를 활성화
    {
        if (LevelNumber.selectLevel >= 0)
        {
            RandomInt = Random.Range(0, 4);
            
        }
        Debug.Log("맵 활성화");
        Debug.Log(RandomInt + " 랜덤 숫자");
        MapObject = MapRandom[RandomInt];
        MapObject.gameObject.SetActive(true);
    }
}
