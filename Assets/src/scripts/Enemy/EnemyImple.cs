using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyImple : MonoBehaviour, Enemy
{
    public enum Status { 
        MOVE,
        STOP
    }

    private Transform target;
    public NavMeshAgent navMeshAgent;
    private Rabbit rabbit;

    public float speed = 1;
    public bool isMove;
    public Status status;

    protected virtual void Awake()
    {
        rabbit = Rabbit.Instance;
        target = rabbit.transform;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();        
    }

    private void Update()
    {        
        SetMoving(isMove);
        if (status == Status.MOVE)
            navMeshAgent.SetDestination(target.position);
    }

    private void SetMoving(bool value)
    {
        if (value)
        {
            navMeshAgent.speed = this.speed;
            this.status = Status.MOVE;
        }
        else
        {
            navMeshAgent.speed = 0;
            this.status = Status.STOP;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;
        Rabbit rabbit = collision.gameObject.GetComponent<Rabbit>(); // find Rabbit instance
        rabbit.DropEgg(); // Rabbit Carry Egg Clear
        rabbit.OnHit(this); // Rabbit OnHit Call
    }
}
