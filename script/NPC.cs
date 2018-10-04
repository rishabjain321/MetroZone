using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : interactable {

    public string[] dialogue;
    public string name2;

    public override void Interact() {
        DialogControl.Instance.AddNewDialogue(dialogue,name2);
        Debug.Log("talk");
    }
}
