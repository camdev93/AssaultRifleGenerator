using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    Canvas ui;
    Slider healthBar;
    Animator anim;
    NavMeshAgent agent;
    Vector3 player;

    [HideInInspector]
    public float health, maxHealth_1 = 100f, maxHealth_2 = 300f;

    void Start()
    {
        ui = GetComponentInChildren<Canvas>();
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        healthBar = GetComponentInChildren<Slider>();

        if (this.gameObject.transform.tag == "Zombie1")
        {
            health = maxHealth_1;
            healthBar.maxValue = maxHealth_1;
        }
        else if(this.gameObject.transform.tag == "Zombie2")
        {
            health = maxHealth_2;
            healthBar.maxValue = maxHealth_2;
        }
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        healthBar.value = health;
        ui.transform.LookAt(player);

        if (Vector3.Distance(agent.transform.position, player) > agent.stoppingDistance)
        {
            if (this.gameObject.transform.tag == "Zombie1")
            {
                Walk();
            }else if(this.gameObject.transform.tag == "Zombie2")
            {
                Run();
            }
        }
        else
        {
            Attack();
        }

        if (health <= 0f)
        {
            Die();
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

    void Die()
    {
        Destroy(this.gameObject, 10f);
        anim.SetBool("isDead", true);
        agent.speed = 0;
    }
}
