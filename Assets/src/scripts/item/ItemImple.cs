using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemImple : MonoBehaviour, Item
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter!");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit");
    }
}
