using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyController
{
    public EnemyManager enemyManager;
    public float coolTime;
    public void Summon()
    {
        enemyManager.SummonEnemey();
    }
    public IEnumerator SummonCoroutine()
    {
        while (true)
        {
            Summon();
            yield return new WaitForSeconds(coolTime);
        }
    }
}