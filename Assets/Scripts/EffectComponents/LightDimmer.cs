using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDimmer : MonoBehaviour
{
    public float speed = 1;
    public float minimumIntensity = 0f;

    Light targetLight;

    void Start()
    {
        targetLight = GetComponent<Light>();
    }

    void Update()
    {
        targetLight.intensity = Mathf.Max(targetLight.intensity - speed * Time.deltaTime, minimumIntensity);
    }
}
