using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorChanger : MonoBehaviour
{
    public string colorName = "_Color";
    public float speed = 1;
    public Gradient gradient;
    public AnimationCurve intensityCurve = AnimationCurve.Linear(0,0,1,1);

    private float elapsed = 0;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    void Update()
    {
        elapsed = Mathf.Max(elapsed - Time.deltaTime * speed, 0f);
        mat.SetColor(colorName, gradient.Evaluate(elapsed) * intensityCurve.Evaluate(elapsed));
    }

    public void Bounce()
    {
        elapsed = 1.0f;
    }
}
