using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides a musical scale and manages changes to the scale.
/// </summary>
public class ScaleSource : MonoBehaviour
{
    public Scales currentScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScale(Scales newScale)
    {
        currentScale = newScale;
    }
}
