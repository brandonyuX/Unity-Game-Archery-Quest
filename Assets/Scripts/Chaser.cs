using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Chaser : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 10f;
    private Animator anim;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent == null)
        {
            Debug.Log("NavMeshAgent not found");
        }

        
        
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            anim.SetTrigger("Run");
            Debug.Log("Chasing Player");
        }
        else
        {
            agent.isStopped = true;
            Debug.Log("Stop Chasing Player");
        }

        //print(distanceToPlayer);

    }

}

