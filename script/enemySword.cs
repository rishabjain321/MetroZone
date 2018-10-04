using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySword : MonoBehaviour, IWeapon
{
    private Animator animator;
    public List<baseStat> Stats { get; set; }
    GameObject player;
    public float timer;
    public float enemydmg = 5f;


    void Start()
    {
        //animator = GetComponent<Animator>();
        timer = 0;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;
    }


    public void PerformAttack()
    {
        //animator.SetTrigger("Attack1");
        //animator.SetBool("Swing", true);
        Debug.Log(this.name + "Sword Attack!");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
        Debug.Log(this.name + "Sword Attack!");
    }

    void OnTriggerEnter(Collider col)
    {
        //Animation aa= transform.root.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0); i don't know what type should i enter in here
        if (col.tag == "Interactable Object" && transform.root.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack_1")
            || transform.root.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack_2") || transform.root.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack_3"))
        {
            if (timer >= 1.0f)
            {
                Debug.Log("uhhh-ahhh");
                player.GetComponent<CharacterHealth>().DealDamage(enemydmg);
                timer = 0;
                
            }

        }
    }

}
