//put this script on the object containing the camera AS A CHILD
//camera will move with WASD keys or if mouse is moved to edge of window

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{

    public float scrollRate = 10.0f;
    public float rotateRate = 4.0f;
    private float number = 0.0f;

    void Start()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        //scrolling
        if (Input.GetKey(KeyCode.W) ||Input.mousePosition.y / Screen.height >= 1)
        {
            transform.Translate(new Vector3(0, scrollRate, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)||Input.mousePosition.x / Screen.width <= 0)
        {
            transform.Translate(new Vector3(scrollRate * -1, 0, 0) * Time.deltaTime);
        } 
        if (Input.GetKey(KeyCode.S)||Input.mousePosition.y / Screen.height <= 0)
        {
            transform.Translate(new Vector3(0, scrollRate * -1, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)||Input.mousePosition.x / Screen.width >= 1)
        {
            transform.Translate(new Vector3(scrollRate, 0, 0) * Time.deltaTime);
        }

        //zoom in and zoom out
    
        if (Input.GetAxis("Mouse ScrollWheel")>0&&transform.position.y>10)
        {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y-.3f,transform.position.z);
            
            //transform.Rotate(new Vector3(0, -Input.GetAxis("Mouse X") * rotateRate, 0));
            //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }
        if (Input.GetAxis("Mouse ScrollWheel")< 0 && transform.position.y < 20)
        {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
            
        }

        //Debug.Log (Input.mousePosition);
    }
}
