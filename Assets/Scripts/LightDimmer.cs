using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDimmer : MonoBehaviour
{
    public float speed = 1;

    Light targetLight;

    void Start()
    {
        targetLight = GetComponent<Light>();
    }

    void Update()
    {
        targetLight.intensity -= speed * Time.deltaTime;
    }
}
