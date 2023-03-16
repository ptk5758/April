using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyImple : MonoBehaviour, Enemy
{
    private Transform target;
    public NavMeshAgent navMeshAgent;
    private Rabbit rabbit;

    private void Awake()
    {
        rabbit = Rabbit.Instance;
        target = rabbit.transform;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag != "Player") return;
        Rabbit rabbit = collision.gameObject.GetComponent<Rabbit>(); // find Rabbit instance
        rabbit.DropEgg(); // Rabbit Carry Egg Clear
        rabbit.OnHit(this); // Rabbit OnHit Call
        // collision.gameObject.GetComponent<Rabbit>().OnHit(this);

    }
}
