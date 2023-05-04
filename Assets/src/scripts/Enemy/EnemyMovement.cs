using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{

    private Vector3 target;
    public float UpdateSpeed = 0.1f;
    private NavMeshAgent Agent;
    private Rabbit rabbit;
    public float range;
    public Transform centrePoint;
    public Vector3 HomePosition;

    private void Awake()
    {
        rabbit = Rabbit.Instance;
        target = rabbit.GetTransform().position;
        HomePosition = transform.position;
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        StartCoroutine(FollowTarget());
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds wait = new WaitForSeconds(UpdateSpeed); 

        while (enabled)
        {
            if (Vector3.Distance(transform.position, rabbit.GetTransform().position) < 10)
            {
                Agent.speed = 3.5f;
                Agent.SetDestination(rabbit.GetTransform().transform.position);
                Debug.Log("!");
            }
            else if (Vector3.Distance(transform.position, rabbit.GetTransform().position) < 15)
            {
                Agent.speed = 3.5f;
                Agent.SetDestination(rabbit.GetTransform().transform.position);
                Debug.Log("?");
            }
            else if (Vector3.Distance(transform.position, rabbit.GetTransform().position) < 16)
            {
                target = HomePosition;
                Agent.SetDestination(target);
            }
            else if (Vector3.Distance(transform.position, rabbit.GetTransform().position) > 20)
            {
                DoPatrol();
            }
            else
            {
                DoPatrol();
            }
            yield return wait;
        }
    }

    private void DoPatrol()
    {
        if (Agent.remainingDistance <= Agent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                Agent.SetDestination(point);
            }
        }
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
        rabbit.OnHit(this.gameObject.GetComponent<Fox>()); // Rabbit OnHit Call
    }
}