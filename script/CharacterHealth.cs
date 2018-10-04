using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour {

    public float CurrentHealth = 100f;
    public float MaxHealth = 200f;
    public float regenRate = 5f;
    private Animator animator;
    //public GameObject player;
   

    public Slider healthbar;

    void Start(){
        animator = GetComponent<Animator>();
        CurrentHealth = MaxHealth;
        healthbar.value = CalculatedHealth();
       
    }

    void Update()
    {

        if (CurrentHealth < MaxHealth)
        {
            CurrentHealth += regenRate * Time.deltaTime;

        }
        
    }

    public void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healthbar.value = CalculatedHealth();
        if (CurrentHealth <= 0)
            Die();
    }

    float CalculatedHealth(){
        return CurrentHealth / MaxHealth;
    }

    public void Die()
    {
        CurrentHealth = 0;
        animator.SetTrigger("Die");
        Debug.Log("You dead.");
        Destroy(this);
        GameObject.Find("/Canvases/MENU/Death").SetActive(true);
    }
}
