using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerWeaponController : MonoBehaviour {

    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }
    private Animator animator;
    public GameObject effect1;
    public GameObject effect5;
    public GameObject attack1,attack2,attack3;
    public float time = 0.5f;
    Transform target;
    public GameObject enemy, spell1Attack;
    

    IWeapon equippedWeapon;
    //NavMeshAgent agent;

    CharacterStat characterStats;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterStats = GetComponent<CharacterStat>();
        //target = GameObject.Find("redWarrior").GetComponent<Transform>();
        //enemy = GameObject.Find("redWarrior");
    }

    void Update()
    {
        //float distance = Vector3.Distance(enemy.transform.position, transform.position);
        //if (distance <= agent.stoppingDistance)
        //{

          //  FaceTarget();
        //}
        if (Input.GetKeyDown(KeyCode.A)||Input.GetMouseButtonDown(0))
        {
            //if()
            animator.SetTrigger("Attack1");
            Invoke("attack1Effect", 0.3f);
            GetComponent<characterMana>().ManaWaste(10);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            
            animator.SetTrigger("Attack2");
            Invoke("attack2Effect", 0.2f);
            GetComponent<characterMana>().ManaWaste(10);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<characterMana>().ManaWaste(30);
            animator.SetTrigger("Attack3");
            Invoke("attack3Effect", time);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PerformWeaponSpecialAttack();
            animator.SetTrigger("Sp1");
            Invoke("spell1Effect", 0.8f);
            GetComponent<characterMana>().ManaWaste(30);
            spell1Attack.SetActive(true);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //PerformWeaponSpecialAttack();
            animator.SetTrigger("Sp2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //PerformWeaponSpecialAttack();
            animator.SetTrigger("Sp3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //PerformWeaponSpecialAttack();
            animator.SetTrigger("Sp4");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //PerformWeaponSpecialAttack();
            animator.SetTrigger("Sp5");
            Invoke("spell5Effect", 0.45f);
            GetComponent<characterMana>().ManaWaste(200);
        }
    }

    public void EquipWeapon(Item itemToEquip)
    {

        if (EquippedWeapon != null)
        {
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("weapons/" + itemToEquip.ObjectSlug),
                                                 playerHand.transform.position, playerHand.transform.rotation);

        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        equippedWeapon.Stats = itemToEquip.Stats;

        EquippedWeapon.transform.SetParent(playerHand.transform);
        characterStats.AddStatBonus(itemToEquip.Stats);
        Debug.Log(equippedWeapon.Stats[0].GetCalculateStatValue());
    }

    public void Deathcheck() {
        if (GetComponent<CharacterHealth>().CurrentHealth == 0)
        {
            animator.SetTrigger("Die");
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void PerformWeaponAttack(){

        equippedWeapon.PerformAttack();
        Debug.Log(equippedWeapon);
    }

    public void PerformWeaponSpecialAttack()
    {

        equippedWeapon.PerformSpecialAttack();
    }
    public void attack1Effect()
    {
        attack1.SetActive(true);
    }

    public void attack2Effect() {
        attack2.SetActive(true);
    }
    public void attack3Effect()
    {
        attack3.SetActive(true);
    }
    public void spell1Effect() {
        effect1.SetActive(true);
    }
    public void spell5Effect() {
        effect5.SetActive(true);
    }
}
