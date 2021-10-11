using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycler : MonoBehaviour
{
    public Gradient gradient;
    public bool looped = true;
    public float baseCycleDuration = 1f;

    private Material material;
    private float elapsedTime;
    private float duration;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        elapsedTime = 0f;
        material.color = gradient.Evaluate(1.0f);
        duration = baseCycleDuration;
    }

    private void Update()
    {
        if (duration > 0f)
        {
            elapsedTime += Time.deltaTime;
            if (looped)
            {
                var pos = (elapsedTime % duration) / duration;
                material.color = gradient.Evaluate(pos);
            }
            else if (elapsedTime <= duration)
            {
                var pos = elapsedTime / duration;
                material.color = gradient.Evaluate(pos);
            }
        }
    }

    public void ScaleCycleDuration(float factor)
    {
        duration = baseCycleDuration * factor;
        elapsedTime = 0f;
    }

    public void SetStartColorRedAmount(float amount)
    {
        gradient.colorKeys[0].color.r = amount % 1.0f;
    }

    public void SetStartColorBlueAmount(float amount)
    {
        gradient.colorKeys[0].color.b = amount % 1.0f;
    }

    public void SetStartColorGreenAmount(float amount)
    {
        gradient.colorKeys[0].color.g = amount % 1.0f;
    }
}
