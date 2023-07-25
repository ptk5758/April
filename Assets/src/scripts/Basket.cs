using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // private Rabbit rabbit;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GameManager.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Player") return;
        Rabbit rabbit = other.gameObject.GetComponent<Rabbit>();
        // 알 갯수 가져오기
        int eggCount = rabbit.eggInventory.Count;

        // 알 비워 주기
        rabbit.eggInventory.Clear();

        // 게임 메니저에 반영 해주기
        GameManager.eggCount += eggCount;
    }

}
