using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyImple : MonoBehaviour, Enemy
{
    private Vector3 target;
    public NavMeshAgent navMeshAgent;
    private Rabbit rabbit;
    public float speed = 1;
    public Enemy.Status status = Enemy.Status.STOP;
    public Vector3 HomePosition;
    public float range;
    public Transform centrePoint;

    protected virtual void Awake()
    {
        rabbit = Rabbit.Instance;
        target = rabbit.GetTransform().position;
        HomePosition = transform.position;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ActionListener();
        RabbitDetectListener();
    }

    private void RabbitDetectListener()
    {
        float range = Vector3.Distance(transform.position, rabbit.GetTransform().position);
        if (range > (int)Enemy.Range.FAR) status = Enemy.Status.STOP;
        else if (range > (int)Enemy.Range.MIDDLE) status = Enemy.Status.WARNING;
        else if (range > (int)Enemy.Range.SHORTS) status = Enemy.Status.MOVE;
        else DoPatrol();
        // this.status = range > (int)Range.FAR ? Status.STOP : range > (int)Range.MIDDLE ? Status.WARNING : Status.MOVE;
    }

    private void ActionListener()
    {
        if (status == Enemy.Status.MOVE) DoMove();
        if (status == Enemy.Status.STOP) DoStop();
    }

    private void LateUpdate()
    {
        navMeshAgent.SetDestination(target);
    }

    private void DoMove()
    {
        navMeshAgent.speed = 1f; 
        target = rabbit.GetTransform().position;
    }
    private void DoStop()
    {
        navMeshAgent.speed = 1f;
        target = HomePosition;
    }

    private void DoPatrol()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                navMeshAgent.SetDestination(point);
            }
        }
        Debug.Log("X");
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;
        Rabbit rabbit = collision.gameObject.GetComponent<Rabbit>(); // find Rabbit instance
        rabbit.DropEgg(); // Rabbit Carry Egg Clear
        rabbit.OnHit(this); // Rabbit OnHit Call
    }
}