using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private int foxPointCount; //여우의 포인트 개수
    private Transform[] foxPoints;// 여우포인트 정보
    private int currentIndex = 0;//목표인덱스

    private EnemyMovement enemyMovement;    
    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }
}
