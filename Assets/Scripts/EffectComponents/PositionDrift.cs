using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDrift : MonoBehaviour
{
    public AnimationCurve driftCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public Vector3 influence = Vector3.up;
    public float speed = 1;
    public float period = 1;

    private float elapsed = 0;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.localPosition;
    }


    private void Update()
    {
        elapsed = (elapsed + Time.deltaTime) % period;
        var drift = driftCurve.Evaluate(elapsed * speed);
        transform.localPosition = startPosition + influence * drift;
    }

    public void ResetStartPosition()
    {
        transform.localPosition = Vector3.zero;
        startPosition = transform.localPosition;
    }
}
