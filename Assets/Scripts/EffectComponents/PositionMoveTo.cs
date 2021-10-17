using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMoveTo : MonoBehaviour
{
    public Transform target { get; set; }
    public float speed = 1f;


    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        }
    }
}
