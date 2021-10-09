using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// A musical being animates and plays music notes.
/// It reacts to stimuli in the world.
/// </summary>
public class MusicalBeing : MonoBehaviour
{
    public AudioMixerGroup mixerGroup;
    public float basevolume = 1.0f;
    public float basePitch = 1.0f;

    public AudioClip[] clips;

    private TempoSource tempoSource;
    private int lastBeatHandled = -1;
    private int nextNoteNumber = 69;

    private List<AudioSource> sources = new List<AudioSource>();

    private static readonly float intervalConstant = Mathf.Pow(2f, 1.0f / 12f);
    private static readonly int middleNoteNumber = 69;

    void Start()
    {
        tempoSource = FindObjectOfType<TempoSource>();

        // the ur AudioSource.
        var go = new GameObject($"{gameObject.name}Audio0");
        go.transform.SetParent(transform);
        go.transform.localPosition = Vector3.zero;
        var src = go.AddComponent<AudioSource>();
        src.playOnAwake = false;
        src.spatialBlend = 1.0f;
        sources.Add(src);
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
        PlayNote(nextNoteNumber);
        nextNoteNumber++;
        lastBeatHandled = currentBeat;
    }

    void PlayNote(int noteNumber)
    {
        var diff = noteNumber - middleNoteNumber;
        var pitch = Mathf.Pow(intervalConstant, diff);
        Debug.Log(pitch);

        foreach (var src in sources)
        {
            if (!src.isPlaying)
            {
                src.clip = clips.RandomItem();
                src.pitch = pitch;
                src.Play();
                return;
            }
        }

        var newSrc = CloneSource();
        newSrc.clip = clips.RandomItem();
        newSrc.pitch = pitch;
        newSrc.Play();
    }

    AudioSource CloneSource()
    {
        var go = Instantiate<GameObject>(sources[0].gameObject, transform);
        var src = go.GetComponent<AudioSource>();
        sources.Add(src);
        return src;
    }
}