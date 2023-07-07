using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    DetectObserver detectObserver;
    Destination destination;
    private void Awake()
    {
        this.detectObserver = new DetectObserver();
        this.destination = new Destination(gameObject.GetComponent<NavMeshAgent>());
    }
    private void OnCollisionEnter(Collision collision)
    {
        detectObserver.DetectedObject(collision.gameObject);
    }
    private void FixedUpdate()
    {
        
    }
}
class Destination
{
    NavMeshAgent navMeshAgent;
    public Destination(NavMeshAgent navMeshAgent)
    {
        this.navMeshAgent = navMeshAgent;
    }

    public void SetTarget(Transform transform)
    {
        this.navMeshAgent.SetDestination(transform.position);
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
