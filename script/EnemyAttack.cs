using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{

    public int random;
    public Animator animator;
    [HideInInspector] int rando;
    bool animDone;
    //float dist;
    //NavMeshAgent navmesh;

    IWeapon equippedWeapon;

    CharacterStat characterStats;

    void Start()
    {
        //BecomeEnemy be = GetComponent<BecomeEnemy>();
        //dist = be.distance;
        //navmesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        characterStats = GetComponent<CharacterStat>();
        //StartCoroutine(NumberGen());
    }

    void Update()
    {
        /*if(dist<= navmesh.stoppingDistance)
        {
            Invoke("AttackSelector", 5);
        }
        */
    }

    public void AttackSelector()
    {
        //Debug.Log("Enemy should Fight");
        if(GameObject.Find("Player").GetComponent<CharacterHealth>().CurrentHealth > 0)
        {

            rando = Random.Range(1, 4);
            //Debug.Log(rando);
            if (rando == 1)
            {
                animator.SetTrigger("Attack1");
                animDone = true;
            }
            else if (rando == 2) {
                animator.SetTrigger("Attack2");
                animDone = true;
            }
            else {
                animator.SetTrigger("Attack3");
                animDone = true;
            }

            }


        }
    IEnumerator NumberGen()
    {
        while (animDone)
        {
            
            yield return new WaitForSeconds(5);
            animDone = false;
            Debug.Log(rando);
        }
    }
    /*public void randomNumberGenerator() {
        rando = UnityEngine.Random.Range(1, 4);
        Debug.Log(rando);
    }*/
    }


