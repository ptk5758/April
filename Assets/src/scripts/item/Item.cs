using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        Rabbit instance = other.gameObject.GetComponent<Rabbit>();
        instance.isItem = true;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rabbit instance = other.gameObject.GetComponent<Rabbit>();
            instance.isItem = false;
        }
    }
}
