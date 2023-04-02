using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    
    private Transform Target;
    public float UpdateSpeed = 0.1f;
    private NavMeshAgent Agent;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Target = Rabbit.Instance.GetTransform();
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
            if (Vector3.Distance(transform.position, Target.position) < 10) {
                Agent.speed = 3.5f;
                Agent.SetDestination(Target.transform.position);
            } else if (Vector3.Distance(transform.position, Target.position) < 15) {
                Agent.speed = 3.5f;
                Agent.SetDestination(Target.transform.position);
            }
            else
            {
                Agent.speed = 0f;
            }
            yield return wait;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;
        Rabbit rabbit = collision.gameObject.GetComponent<Rabbit>(); // find Rabbit instance
        rabbit.DropEgg(); // Rabbit Carry Egg Clear
        // rabbit.OnHit(this); // Rabbit OnHit Call
    }
}