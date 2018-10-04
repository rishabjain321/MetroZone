using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class camerafollow : MonoBehaviour {

    public GameObject cam;

    // Update is called once per frame
    void Update () {
        cam.transform.position = gameObject.transform.position;
	}
}
