using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public GameObject target;
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) destination.Start();
        if (Input.GetKeyDown(KeyCode.Alpha2)) destination.Stop();
    }
    private void FixedUpdate()
    {
        if (target != null) destination.SetTarget(target.transform);
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
    // 하드코딩
    public void Stop()
    {        
        this.navMeshAgent.speed = 0;
    }
    // 하드코딩
    public void Start()
    {
        this.navMeshAgent.speed = 3.5f;
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
