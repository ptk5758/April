using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static List<Transform> summonPoint = new List<Transform>();
    private void Awake()
    {
        InitializSummonPoint();
    }

    private void InitializSummonPoint()
    {
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();
        for (int i = 1; i < transforms.Length; i++) summonPoint.Add(transforms[i]);
    }

}
