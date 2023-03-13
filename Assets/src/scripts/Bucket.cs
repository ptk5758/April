using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Player") return;
        Rabbit rabbit = other.gameObject.GetComponent<Rabbit>();
        List<Egg> eggs = rabbit.GetEgg();
        GameManager gameManager = GameManager.Instance;
        gameManager.eggCount += eggs.Count;
        eggs.Clear();
    }

}
