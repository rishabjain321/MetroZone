using System.Collections.Generic;

public interface IWeapon{
    List<baseStat> Stats { get; set; }
    void PerformAttack();
    void PerformSpecialAttack();
}
