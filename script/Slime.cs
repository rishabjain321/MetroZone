using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy {

    public float currentHealth, power, toughness;
    public float maxHealth;
    private Animator animator;
    public GameObject enemy;
    GameObject player;

    void Start() {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        enemy = GameObject.Find("redWarrior");
        player = GameObject.Find("Player");
    }
    //void update() {
      //  timer += Time.deltaTime;
       // Debug.Log(timer);
    //}
    public void PerformAttack()
    {
        
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }

    void Die() {
        animator.SetTrigger("Die");
        player.GetComponent<characterMana>().ManaGain(100);
        //if (timer >= 3)
        Invoke("timeToDie", 0.3f);
    }

    void trigger() {
        animator.enabled = false;
    }
    void timeToDie() {
        Destroy(gameObject);
        //GameObject.Find("redWarrior").SetActive(false);
    }
}
