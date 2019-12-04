using System.Collections;
using System.Collections.Generic;
//using System;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPilot : MonoBehaviour
{
    public Transform targetLocation;
    public int rangeOfDetection;
    public Transform[] points;
    
    
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool attack;
    private int layerMask;
    private System.Random rnd;

    void Start()
    {
        rnd = new System.Random();
        attack=false;
        agent = GetComponent<NavMeshAgent>();
        layerMask = 1 << 8;
        agent.autoBraking = false;

            GotoNextPoint();
    }

    void FixedUpdate()
    {
        if(!attack){
        if (!agent.pathPending && agent.remainingDistance < 0.5f){
                GotoNextPoint();
        }
        Vector3 direction = PlayerPilot.playerPosition - transform.position;
        Debug.DrawRay(transform.position, direction, Color.green, 10, false);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, rangeOfDetection, layerMask))
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            if(!attack){
            InvokeRepeating("Attack", 0.0f, 3.0f);
            }
            attack=!attack;
        }
        }
        else{
            //agent.SetDestination(transform.position);

            //Debug.Log("Attacking");
        }
    }
     void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }
        void Attack(){
            int num = rnd.Next(100);
            Debug.Log("You roll "+num);

            if(num>25)
            Debug.Log("Attacking");
            else
            Debug.Log("Missing :(");
        }

    
}
