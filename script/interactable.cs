using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class interactable : MonoBehaviour {
    
    public float distance = 1.5f;
    [HideInInspector] public NavMeshAgent playerAgent;
    private bool hasInteracted;



    public virtual void MoveToInteraction(NavMeshAgent playerAgent) {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = distance;
        playerAgent.destination = this.transform.position;
        
    }

    void Update()
    {
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending && playerAgent.stoppingDistance != 0)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance) {
                Interact();
                hasInteracted = true;
            }
            else {
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact() {
        Debug.Log("interacting with base class.");
    }
}
