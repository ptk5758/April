using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Player") return;
        Debug.Log(other);
    }

}
