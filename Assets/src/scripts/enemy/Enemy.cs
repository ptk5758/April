using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    DetectObserver detectObserver;
    private void Awake()
    {
        this.detectObserver = new DetectObserver();
    }
    private void OnCollisionEnter(Collision collision)
    {
        detectObserver.DetectedObject(collision.gameObject);
    }
}

class DetectObserver
{
    public void DetectedObject(GameObject gameObject)
    {
        if (gameObject.tag == "Player") DetectedPlayer();
    }

    public void DetectedPlayer()
    {
        Rabbit.instance.Spawn();
    }
}