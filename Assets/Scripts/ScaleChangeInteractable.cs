using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChangeInteractable : MonoBehaviour
{
    public Scales targetScale;
    private ScaleSource scaleSource;

    private void Start()
    {
        scaleSource = FindObjectOfType<ScaleSource>();
    }

    public void DoInteraction()
    {
        scaleSource.ChangeScale(targetScale);
    }
}
