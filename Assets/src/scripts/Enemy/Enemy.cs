using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IEnemy
{
    public Transform target;
    public NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag != "Player") return;
        collision.gameObject.GetComponent<Rabbit>().OnHit(this);

    }
}
