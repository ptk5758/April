using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject Prefab; //여우 프리팹
    [SerializeField] 
    private Transform[] Points; //여우 생성될 여우의 포인트 정보
    public Transform FoxSpawnGroup; // <- 하위로 오브젝트 생성

    private void Awake()
    {
        Points = transform.GetComponentsInChildren<Transform>();
    }
    public void SpawnFox()
    {        
        GameObject instance = Instantiate(Prefab, FoxSpawnGroup);
        instance.transform.position = Points[Random.Range(1, Points.Length)].position;
    }
}
