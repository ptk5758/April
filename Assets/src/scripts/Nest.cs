using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Player") return;
        Rabbit rabbit = other.gameObject.GetComponent<Rabbit>();
        // int count = rabbit.eggs.Count;
        GameManager gm = GameManager.Instance;        
        // rabbit.eggs.Clear();

    }

}
