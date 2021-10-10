using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootNoteChangeInteractable : MonoBehaviour
{
    public int targetNoteNumber;
    private MusicConductor conductor;

    private void Start()
    {
        gameObject.name = $"Change root to {targetNoteNumber}";
        conductor = FindObjectOfType<MusicConductor>();
    }

    public void DoInteraction()
    {
        conductor.ChangeRootNote(targetNoteNumber);
    }
}
