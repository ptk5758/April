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
        int eggCount = rabbit.eggInventory.Count;
        GameManager.eggCount += eggCount;
        rabbit.eggInventory.Clear();
    }

}
