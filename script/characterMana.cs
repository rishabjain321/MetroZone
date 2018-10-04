using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterMana : MonoBehaviour
{

    public float CurrentMana { get; set; }
    public float MaxMana = 20f;

    public float regenRate = 0.1f;


    public Slider Manabar;

    void Start()
    {
        CurrentMana = MaxMana;
        //Manabar.value = CalculatedMana();
    }

    void Update()
    {
        if (CurrentMana < MaxMana)
        {
            CurrentMana += regenRate * Time.deltaTime;
            
        }
        Manabar.value = CalculatedMana();
    }

    public void ManaWaste(float manawaste)
    {
        CurrentMana -= manawaste;
        //Manabar.value = CalculatedMana();
        if (CurrentMana <= 0)
            NotEnoughMana();
    }

    public void ManaGain(float managain)
    {
        CurrentMana += managain;
        //Manabar.value = CalculatedMana();
    }

    float CalculatedMana()
    {
        return CurrentMana / MaxMana;
    }

    void NotEnoughMana()
    {
        CurrentMana = 0;
        Debug.Log("Not enough Mana!");
        GetComponent<dash>().enabled = false;
    }
}
