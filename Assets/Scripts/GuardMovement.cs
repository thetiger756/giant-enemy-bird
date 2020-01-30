using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardMovement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    Vector3 target;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            //find the players position
            target = GameObject.FindGameObjectWithTag("Player").transform.position;

            agent.SetDestination(target);
        }
    }
}
