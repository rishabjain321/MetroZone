using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;
    public List<baseStat> Stats { get; set; }

    public float timer;


    void Start() {
        //animator = GetComponent<Animator>();
        timer = 0;
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
        Animator aa = transform.root.gameObject.GetComponent<Animator>();
        //GetCurrentAnimatorStateInfo(0); //i don't know what type should i enter in here
        if (col.tag == "Interactable Object"&& aa.GetCurrentAnimatorStateInfo(0).IsName("Attack_1")
            || aa.GetCurrentAnimatorStateInfo(0).IsName("Attack_2")|| aa.GetCurrentAnimatorStateInfo(0).IsName("Attack_3")
            || aa.GetCurrentAnimatorStateInfo(0).IsName("Skill_1"))
        {
            if (timer >= 1.0f)
            {
                Debug.Log("uhhh-ahhh");
                col.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculateStatValue());
                timer = 0;
            }
            
        }
    }

}
