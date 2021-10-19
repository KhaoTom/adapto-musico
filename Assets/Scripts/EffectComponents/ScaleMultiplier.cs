using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMultiplier : MonoBehaviour
{
    public float scaleMultiplierPerStep = 0.95f;
    public Transform targetTransform;

    public void MultiplyScaleByOneStep()
    {
        targetTransform.localScale *= scaleMultiplierPerStep;
    }

    public void MultiplyScaleByAmount(float amount)
    {
        targetTransform.localScale *= amount;
    }
}
