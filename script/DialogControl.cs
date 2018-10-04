using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DialogControl : MonoBehaviour {
     
    public static DialogControl Instance { get; set; }
    public GameObject dialoguePanel;
    public string npcName;
    public List<string> dialogueLines = new List<string>();
    
    ///////////////////////
    
    [HideInInspector] public GameObject options;
    [HideInInspector] public GameObject text;
    [HideInInspector] public GameObject continueButton;
    Button continueBtn,fightBtn,friendBtn;
    Text dialogueText, nameText;
    int dialogueIndex;
    public GameObject fightButton,friendButton;
    //public string npcname;

    GameObject dialog;

    void Awake () {
        dialog = GameObject.Find("Canvas");
        continueBtn = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        fightBtn = dialoguePanel.transform.Find("Options").GetChild(0).GetComponent<Button>();
        friendBtn = dialoguePanel.transform.Find("Options").GetChild(1).GetComponent<Button>();
        /*if(Input.GetKeyDown(KeyCode.Escape)){
            dialoguePanel.SetActive(false);
        }*/
        continueBtn.onClick.AddListener(delegate { ContinueDialogue(); });

        dialoguePanel.SetActive(false);

        /*fightBtn.interactable = false;
        fightBtn.GetComponent<Renderer>().enabled = false;
        friendBtn.interactable = false;
        fightBtn.GetComponent<Renderer>().enabled = false;*/

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }

	}

    public void AddNewDialogue(string[] lines, string npcName) {
        GameObject findNpc = GameObject.Find(npcName);
        if (!findNpc.GetComponent<BecomeEnemy>().isActiveAndEnabled)
        {
            //Debug.Log("add");
            //dialoguePanel.SetActive(true);
            //dialog.SetActive(true);
            dialogueIndex = 0;
            dialogueLines = new List<string>(lines);
            //dialogueLines.AddRange(lines);
            this.npcName = npcName;

            Debug.Log(dialogueLines.Count);
            if (npcName != null)
            {
                findNpc.GetComponent<BecomeEnemy>().enabled = false;
                findNpc.GetComponent<BecomeFriend>().enabled = false;
                options.SetActive(false);
            }
            //if (findNpc.GetComponent<BecomeEnemy>().isActiveAndEnabled)
            //    continue;
            //else
            CreateDialogue();
        }
        else
        {
            Debug.Log("enemy won't talk to you");
        }
    }

    public void CreateDialogue() {
        text.SetActive(true);
        continueButton.SetActive(true);
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue() {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else {
            text.SetActive(false);
            continueButton.SetActive(false);
            options.SetActive(true);
            //dialoguePanel.SetActive(false);
            
            fightBtn.onClick.AddListener(fightBtnClicked);
            friendBtn.onClick.AddListener(friendBtnClicked);

            

        }
    }

    public void fightBtnClicked() {
        GameObject findNpc = GameObject.Find(npcName);
        findNpc.GetComponent<BecomeEnemy>().enabled = true;
        dialoguePanel.SetActive(false);
        //dialog.SetActive(false);

    }

    public void friendBtnClicked() {
        GameObject findNpc = GameObject.Find(npcName);
        findNpc.GetComponent<BecomeFriend>().enabled = true;
        dialoguePanel.SetActive(false);
        //dialog.SetActive(false);
    }
}
