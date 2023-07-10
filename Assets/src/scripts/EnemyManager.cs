using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    static List<Transform> summonPoint = new List<Transform>();
    float coolTime = 10f;
    private void Awake()
    {
        InitializSummonPoint();
    }
    private void Update()
    {

    }

    private void InitializSummonPoint()
    {
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();
        for (int i = 1; i < transforms.Length; i++) summonPoint.Add(transforms[i]);
    }

    public void SummonEnemey()
    {
        GameObject enemy = Instantiate(enemyPrefab, GetRandomSummonPoint());
    }
    private Transform GetRandomSummonPoint()
    {
        return summonPoint[Random.Range(0, summonPoint.Count)];
    }
}
