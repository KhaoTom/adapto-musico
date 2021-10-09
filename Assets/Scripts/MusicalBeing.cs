using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A musical being animates and plays music notes.
/// It reacts to stimuli in the world.
/// </summary>
public class MusicalBeing : MonoBehaviour
{
    private TempoSource tempoSource;
    private int lastBeatHandled = -1;

    void Start()
    {
        tempoSource = FindObjectOfType<TempoSource>();
    }

    void Update()
    {
        var currentBeat = tempoSource.currentBeat;
        if (lastBeatHandled < currentBeat)
        {
            HandleBeat(currentBeat);
        }
    }

    void HandleBeat(int currentBeat)
    {
        // TODO: play notes here and stuff
        lastBeatHandled = currentBeat;
    }
}
