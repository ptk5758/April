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
        GameLevel level = LevelManager.gameLevel;
        switch (level) {
            case GameLevel.EASY:
                coolTime = 30f;
                break;
            case GameLevel.NORMAL:
                coolTime = 25f;
                break;
            case GameLevel.EXPERT:
                coolTime = 20f;
                break;
            case GameLevel.HARD:
                coolTime = 10f;
                break;
        }
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