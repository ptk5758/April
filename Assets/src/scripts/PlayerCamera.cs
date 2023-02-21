using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public Vector3 offset = new Vector3(0, 30, 0);
    private void Update()
    {
        transform.position = target.position + offset;
    }
}
