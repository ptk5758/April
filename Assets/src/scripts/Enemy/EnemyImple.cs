using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyImple : MonoBehaviour, Enemy
{
    private Transform target;
    public NavMeshAgent navMeshAgent;
    private Rabbit rabbit;
    public float speed = 1;
    public Enemy.Status status = Enemy.Status.STOP;

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
        if (range > (int) Enemy.Range.FAR) status = Enemy.Status.STOP;
        else if (range > (int) Enemy.Range.MIDDLE) status = Enemy.Status.WARNING;
        else if (range > (int) Enemy.Range.SHORTS) status = Enemy.Status.MOVE;
        // this.status = range > (int)Range.FAR ? Status.STOP : range > (int)Range.MIDDLE ? Status.WARNING : Status.MOVE;
    }

    private void ActionListener() {
        if (status == Enemy.Status.MOVE) DoMove();
        if (status == Enemy.Status.STOP) DoStop();
    }

    private void LateUpdate()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void DoMove() {
        this.status = Enemy.Status.MOVE;
        navMeshAgent.speed = 1; // 하드코딩
    }
    private void DoStop() {
        this.status = Enemy.Status.STOP;
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
