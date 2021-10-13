using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTransform : MonoBehaviour
{
    public Vector3 axis = Vector3.up;
    public float speed = 10;
    public float delta = 0;
    public float minSpeed = 0;
    public float maxSpeed = 50;

    void Update()
    {
        transform.Rotate(axis, speed * Time.deltaTime);
        speed = Mathf.Clamp(speed + delta * Time.deltaTime, minSpeed, maxSpeed);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
