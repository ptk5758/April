using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeListener : MonoBehaviour
{
    public Fox fox;
    private void Awake()
    {
        fox = gameObject.GetComponentInParent<Fox>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        fox.rangeHandle?.Invoke();
    }
}
