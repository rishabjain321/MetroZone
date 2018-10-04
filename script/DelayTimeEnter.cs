using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayTimeEnter : MonoBehaviour {

    public float delayTimeEnter = 1f;

    void Update()
    {
        Debug.Log("Entered in: " + delayTimeEnter); 
    }
}
