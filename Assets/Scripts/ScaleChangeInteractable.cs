using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChangeInteractable : MonoBehaviour
{
    public Scales targetScale;
    private MusicConductor conductor;

    private void Start()
    {
        gameObject.name = $"Change to {targetScale}.";
        conductor = FindObjectOfType<MusicConductor>();
    }

    public void DoInteraction()
    {
        conductor.ChangeScale(targetScale);
    }
}
