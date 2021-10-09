using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tempo source provides the playback tempo for all musical beings.
/// It is affected by the player's proximity to tempo adjustment relays.
/// </summary>
public class TempoSource : MonoBehaviour
{
    public int defaultBpm = 90;

    private int _bpm;
    public int bpm { get => _bpm; private set { timePerBeat = 60.0f / value; _bpm = value; } }
    public float timePerBeat { get; private set; }
    public float currentBeatStartTime { get; private set; }
    public int currentBeat { get; private set; }

    void Start()
    {
        bpm = defaultBpm;
        currentBeat = 0;
        currentBeatStartTime = Time.time;
    }

    void Update()
    {
        var t = Time.time;
        if (t >= currentBeatStartTime + timePerBeat)
        {
            currentBeat += 1;
            currentBeatStartTime += timePerBeat;
        }
    }
}
