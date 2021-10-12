using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTransform : MonoBehaviour
{
    public Vector3 axis = Vector3.up;
    public float speed = 10;

    void Update()
    {
        transform.Rotate(axis, speed * Time.deltaTime);
    }
}
