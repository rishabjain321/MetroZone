//attach this script to an object you want to move to the location clicked on

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour {

    public LayerMask mask;
    public GameObject cursor;

    void Update () {
		if (Input.GetKey (KeyCode.Mouse1)) {
            cursor.SetActive(true);
            Ray ray = (Camera.main.ScreenPointToRay (Input.mousePosition));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity, mask)) {
                GameObject interactedObject = hit.collider.gameObject;
				if (hit.collider != null && hit.collider.tag != "Player") {
					transform.position = hit.point;
 //                   Debug.Log("hello");
				}

			}
		}
	}
}
