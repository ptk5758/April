using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyImple : MonoBehaviour, Enemy
{
    public enum Status { 
        MOVE,
        STOP,
        WARNING
    }
    public enum Range { 
        SHORTS = 5, // 근접 , 중거리, 원거리
        MIDDLE = 10,
        FAR = 15
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
        RabbitDetectListener();
    }

    private void RabbitDetectListener() {
        float range = Vector3.Distance(transform.position, target.position);
        if (range > (int)Range.FAR) status = Status.STOP;
        else if (range > (int)Range.MIDDLE) status = Status.WARNING;
        else if (range > (int)Range.SHORTS) status = Status.MOVE;
        // this.status = range > (int)Range.FAR ? Status.STOP : range > (int)Range.MIDDLE ? Status.WARNING : Status.MOVE;
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
