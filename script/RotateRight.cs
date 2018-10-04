using UnityEngine;
using System.Collections;

public class RotateRight : MonoBehaviour
{
    public float speed = 10f;


    void Update()
    {
        transform.Rotate(Vector3.right, speed * Time.deltaTime);
    }

}