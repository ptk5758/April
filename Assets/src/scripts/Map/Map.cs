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
        //Update�� Start���� ActiveMap() �Լ��� �����Ű�� �������ڸ� �ι� �޾ƿ��µ� ������ �𸣰��� -> ������ �ñ�
        //if (ActiveBool == true) 
        //{
        //    ActiveMap();
        //    ActiveBool = false; //���� Update�� ���ؼ� ��� �ٲ�� ���� ����?
        //    Debug.Log("����");
        //}

    }

    public void ActiveMap() //���� ���ڸ� �޾Ƽ� �� ���ڿ� �ִ� �迭�� Object�� Ȱ��ȭ
    {
        if (LevelNumber.selectLevel >= 0)
        {
            RandomInt = Random.Range(0, 4);
            
        }
        Debug.Log("�� Ȱ��ȭ");
        Debug.Log(RandomInt + " ���� ����");
        MapObject = MapRandom[RandomInt];
        MapObject.gameObject.SetActive(true);
    }
}
