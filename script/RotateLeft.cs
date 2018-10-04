using UnityEngine;
using System.Collections;

public class RotateLeft : MonoBehaviour
{
    public float speed = 10f;


    void Update()
    {
        transform.Rotate(Vector3.right, speed * Time.deltaTime);
    }

}