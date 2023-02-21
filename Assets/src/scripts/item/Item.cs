using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        Rabbit instance = other.gameObject.GetComponent<Rabbit>();
        instance.item = this;
        instance.isItem = true;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rabbit instance = other.gameObject.GetComponent<Rabbit>();
            instance.isItem = false;
            instance.item = null;
        }
    }
    public abstract void UseItem();
}
