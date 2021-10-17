using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GraphicFade : MonoBehaviour
{
    public bool playOnEnable = false;
    public Graphic graphic;
    public float speed = 1f;
    public Gradient fadeGradient;
    public UnityEvent onFadeFinished;

    private float elapsed = 0f;
    private bool playing = false;

    private void Awake()
    {
        graphic.color = fadeGradient.Evaluate(0f);
    }

    private void OnEnable()
    {
        playing = playOnEnable;
    }

    private void Update()
    {
        if (playing)
        {
            if (elapsed < 1.0f && elapsed > -1.0f)
            {
                elapsed += Time.deltaTime * speed;
                graphic.color = fadeGradient.Evaluate(elapsed);
            }
            else
            {
                playing = false;
                onFadeFinished.Invoke();
            }
        }
    }

    public void PlayFade()
    {
        playing = true;
        elapsed = 0f;
    }
}
