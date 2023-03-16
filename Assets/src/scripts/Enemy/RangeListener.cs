using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeListener : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Test");
    }
}
