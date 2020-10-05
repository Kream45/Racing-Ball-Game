using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float speed = 10f;
    public bool canMove = false;

    void Update()
    {
        if (!canMove) return;

        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            direction += Vector3.forward;

        if (Input.GetKey(KeyCode.DownArrow))
            direction += Vector3.back;

        if (Input.GetKey(KeyCode.LeftArrow))
            direction += Vector3.left;

        if (Input.GetKey(KeyCode.RightArrow))
            direction += Vector3.right;


        var rigidbody = GetComponent<Rigidbody>();
        
        rigidbody.AddForce(direction * speed);


    }
}
