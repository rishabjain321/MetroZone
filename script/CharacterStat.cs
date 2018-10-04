using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour {

    public List<baseStat> stats = new List<baseStat>();


    void Start()
    {
        stats.Add(new baseStat(4,"Power","Your Power level."));
        stats.Add(new baseStat(2, "vitality","Your vitality level."));
    }

    public void AddStatBonus(List<baseStat> statBonuses)//equip weapons
    {
        foreach(baseStat statBonus in statBonuses){
            stats.Find(x=> x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));

        }
    }
    public void RemoveStatBonus(List<baseStat> statBonuses)//unequip weapons
    {
        foreach (baseStat statBonus in statBonuses)
        {
            stats.Find(x => x.StatName == statBonus.StatName).RemoveStatBonus(new StatBonus(statBonus.BaseValue));

        }
    }
}
