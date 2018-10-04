using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BecomeEnemy : MonoBehaviour {

    NavMeshAgent agent;
    Transform target;
    public float lookRadius = 10f;
    GameObject player;
    public float timeToturnAround = 5f;
    public float timer = 0f;
    [HideInInspector] public float distance;
    bool check;
    GameObject gmgm;

    void Start(){
        target = GameObject.Find("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        check = false;
        gmgm = this.gameObject;


    }

    void Update()
    {
        
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= lookRadius) { 
        agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance) {
                //gmgm.GetComponent<AI>().enabled = true;
                //check = true;
                //if (check) {
                    FaceTarget();
                    //Invoke("delayAttack", 3);
                    timer += Time.deltaTime;
                    //check = false;
                    if (timer >= 1.5)
                    {
                        GetComponent<EnemyAttack>().AttackSelector();
                        timer = 0;
                    }
                //}
            }
        }
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*timeToturnAround);
    }

    //void delayAttack() {
        
    //}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
