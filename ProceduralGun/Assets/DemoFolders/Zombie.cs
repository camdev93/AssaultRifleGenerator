using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    Vector3 player;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (Vector3.Distance(agent.transform.position, player) > agent.stoppingDistance)
        {
            if (gameObject.name == "Zombie_1")
            {
                Walk();
            }else if(gameObject.name == "Zombie_2")
            {
                Run();
            }
        }
        else
        {
            Attack();
        }
    }

    void Walk()
    {
        anim.SetInteger("EnemyState", 0);
        agent.SetDestination(player);
    }

    void Run()
    {
        anim.SetInteger("EnemyState", 1);
        agent.SetDestination(player);
    }

    void Attack()
    {
        anim.SetInteger("EnemyState", 2);
        transform.LookAt(player);
    }
}
