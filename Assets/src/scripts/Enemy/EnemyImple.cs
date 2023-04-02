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
    public Status status = Status.STOP;

    protected virtual void Awake()
    {
        rabbit = Rabbit.Instance;
        target = rabbit.GetTransform();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ActionListener();
    }

    private void ActionListener() {
        if (status == Status.MOVE) DoMove();
        if (status == Status.STOP) DoStop();
    }

    private void LateUpdate()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void DoMove() {
        this.status = Status.MOVE;
        navMeshAgent.speed = 1; // 하드코딩
    }
    private void DoStop() {
        this.status = Status.STOP;
        navMeshAgent.speed = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;
        Rabbit rabbit = collision.gameObject.GetComponent<Rabbit>(); // find Rabbit instance
        rabbit.DropEgg(); // Rabbit Carry Egg Clear
        rabbit.OnHit(this); // Rabbit OnHit Call
    }
}
