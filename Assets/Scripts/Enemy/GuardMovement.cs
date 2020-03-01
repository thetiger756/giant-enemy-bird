using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    Vector3 target;

    public Transform[] points;
    private int destPoint = 0;
    private Vector3 guardLocation;
    [SerializeField]
    private int aggressiveness = 40;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        guardLocation = GetComponent<Transform>().position;

        agent.autoBraking = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            //find the players position
            target = GameObject.FindGameObjectWithTag("Player").transform.position;
        }

        if (target.x - guardLocation.x < aggressiveness && target.z - guardLocation.z < aggressiveness)
        {
            agent.SetDestination(target);
        }
        else
        {
            Patrol();

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }

    //void OnDisable()
    //{
    //    Debug.Log("PrintOnDisable: script was disabled");

    //    stunTime();
    //}

    //IEnumerator stunTime()
    //{
    //    yield return new WaitForSeconds(10f);

    //    GetComponent<GuardMovement>().enable = true;

    void Patrol()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
    }

    void GotoNextPoint()
    {
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }
}

