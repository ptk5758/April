using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject Target;
    [SerializeField] 
    private GameObject foxPrefab; //여우 프리팹
    [SerializeField] 
    private Transform[] foxPoints; //여우 생성될 여우의 포인트 정보
    public Transform foxSpawnGroup; // <- 하위로 오브젝트 생성

    public void SpawnFox()
    {        
        GameObject firstFox = Instantiate(foxPrefab, foxSpawnGroup);
        Fox fox = firstFox.GetComponent<Fox>();
        fox.Setup(foxPoints, Target);
    }
}
