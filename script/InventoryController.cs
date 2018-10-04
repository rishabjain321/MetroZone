using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    public PlayerWeaponController playerWeaponController;
    public Item sword;


    void Start(){
        
        playerWeaponController = GetComponent<PlayerWeaponController>();
        List<baseStat> swordStats = new List<baseStat>();
        swordStats.Add(new baseStat(6, "Power", "Your power level"));
        sword = new Item(swordStats, "sword");
        playerWeaponController.EquipWeapon(sword);
    }

    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.V)){
            playerWeaponController.EquipWeapon(sword);
        }*/
    }
}
