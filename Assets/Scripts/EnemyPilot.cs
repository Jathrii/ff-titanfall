using System.Collections;
using System.Collections.Generic;
//using System;
using UnityEngine;
using UnityEngine.AI;

//This script is to only be attached to enemy pilots/titans
public class EnemyPilot : MonoBehaviour
{
    public int rangeOfDetection;
    public int accuracyPercentage;
    public int weaponDamage = 10;
    public int weaponRange = 100;
    public Transform[] points;


    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool attack;
    private int layerMask;
    private System.Random rnd;
    private Vector3 player;

    void Start()
    {
        rnd = new System.Random();
        attack = false;
        agent = GetComponent<NavMeshAgent>();
        layerMask = 1 << 8;
        agent.autoBraking = false;

        GotoNextPoint();
    }

    void FixedUpdate()
    {

        if (!attack)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
            Vector3 direction = PlayerPos.pos - transform.position;
            Debug.DrawRay(transform.position, direction, Color.green, 10, false);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, rangeOfDetection, layerMask))
            {


                if (!attack)
                {
                    GetComponent<NavMeshAgent>().isStopped = true;
                    InvokeRepeating("Attack", 0.0f, 3.0f);
                }


                attack = !attack;
            }
        }
        else
        {

            if (Vector3.Distance(PlayerPos.pos, transform.position) > 10.0f)
            {
                GetComponent<NavMeshAgent>().isStopped = false;
                agent.SetDestination(PlayerPos.pos);


            }
            else
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                transform.LookAt(PlayerPos.pos);
            }

            //Debug.Log("Attacking");
        }
    }
    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }
    void Attack()
    {
        int num = rnd.Next(100);
        //Debug.Log("You roll "+num);
        RaycastHit hit;
        if (num < accuracyPercentage)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, weaponRange))
            {
                Debug.Log("Attacking");

                PlayerPilot target = hit.transform.GetComponent<PlayerPilot>();
                if (target != null)
                {
                    if (target.CompareTag("Player"))
                    {
                        GameObject.Find("Players").transform.Find("PlayerPilot").GetComponent<PlayerPilot>().takeDamage(weaponDamage);
                    }
                }

                PlayerTitan target2 = hit.transform.GetComponent<PlayerTitan>();

                if (target2 != null)
                {
                    if (target2.CompareTag("Player"))
                    {
                        if(!GameObject.Find("Legion").GetComponent<LegionShield>().isShieldActivate())
                            GameObject.Find("Players").transform.Find("PlayerTitan").GetComponent<PlayerTitan>().takeDamage(weaponDamage);
                    }
                }

            }
            else
                Debug.Log("Missing :(");
        }
    }

}
