using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dash : MonoBehaviour {
    // public characterMana mana;
    public float distance = 5f;
    public float speed = 100.0f;

    bool dashing = false;
    RaycastHit hit;

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            //Invoke("teleport", 0.3f);
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.tag != "Player" && Vector3.Distance(transform.position, hit.point) <= distance)
                {
                    //transform.position = hit.point;
                    dashing = true;
                    GetComponent<characterMana>().ManaWaste(60);
                    // GameObject.Find("Player").transform.position = hit.point;
                }
            }
        }
        if (dashing)
        {
            float i = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, hit.point, i);
            GetComponent<NavMeshAgent>().destination = transform.position;
            if (transform.position == hit.point)
            {
                dashing = false;
            }
        }
    }
}
   /* public void teleport() {
        
        Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.tag != "Player" && Vector3.Distance(transform.position, hit.point) <= distance)
            {
                transform.position = hit.point;
                GetComponent<NavMeshAgent>().destination = hit.point;
                GetComponent<characterMana>().ManaWaste(6);


                // GameObject.Find("Player").transform.position = hit.point;
            }
        }*/
    


