using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseStat
{

    public List<StatBonus> BaseAdditives { get; set; }

    public int BaseValue { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set; }


    public baseStat(int baseValue, string statName, string statDescription ){

        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescription;

        }

    public void RemoveStatBonus(StatBonus statBonus){
        this.BaseAdditives.Remove(BaseAdditives.Find(x=> x.BonusValue == statBonus.BonusValue));

    }

    public void AddStatBonus(StatBonus statBonus){

        this.BaseAdditives.Add(statBonus);
    }

    public int GetCalculateStatValue(){
        this.FinalValue = 0;
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
        FinalValue += BaseValue;
        return FinalValue;
    }
}
