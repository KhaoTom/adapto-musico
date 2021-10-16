using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBounce : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 scaleTarget = Vector3.one;
    public Vector3 bounceScale = Vector3.one * 2;

    float elapsed = 0;

    void Update()
    {
        elapsed += Time.deltaTime;
        transform.localScale = Vector3.Lerp(transform.localScale, scaleTarget, elapsed * speed);
    }

    public void Bounce()
    {
        transform.localScale = bounceScale;
        elapsed = 0;
    }
}
