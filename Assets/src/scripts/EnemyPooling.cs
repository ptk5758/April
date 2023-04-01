using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject prefab;
    private void Awake()
    {
        PointInit();
    }
    private void PointInit()
    {
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            spawnPoints[i] = transform.GetChild(i);
    }

    public void SpawnEnemy()
    {
        Instantiate(prefab, spawnPoints[Random.Range(0, transform.childCount)]);
    }
}
