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

    private List<AudioSource> sources = new List<AudioSource>();

    private IMusicSequence currentSequence;

    private static readonly float intervalConstant = Mathf.Pow(2f, 1.0f / 12f);
    private static readonly int middleNoteNumber = 69;

    void Start()
    {
        tempoSource = FindObjectOfType<TempoSource>();

        // create the ur AudioSource.
        var go = new GameObject($"{gameObject.name}Audio0");
        go.transform.SetParent(transform);
        go.transform.localPosition = Vector3.zero;
        var src = go.AddComponent<AudioSource>();
        src.playOnAwake = false;
        src.spatialBlend = 1.0f;
        sources.Add(src);

        currentSequence = new SimpleSequence()
        {
            notes = new int[] { 69, 72, 76 }
        };
        currentSequence.Start(0);
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
        var note = currentSequence.GetNote(currentBeat);
        PlayNote(note);
        lastBeatHandled = currentBeat;
    }

    void PlayNote(Note note)
    {
        if (note == Note.None) return;

        var diff = note.noteNumber - middleNoteNumber;
        var pitch = Mathf.Pow(intervalConstant, diff);
        var volume = basevolume;

        PlayOnNextAvailableSource(clips.RandomItem(), pitch, volume);
    }

    void PlayOnNextAvailableSource(AudioClip clip, float pitch, float volume)
    {
        var src = GetFirstAvailableSource();
        src.clip = clip;
        src.pitch = pitch;
        src.volume = volume;
        src.Play();
    }

    AudioSource GetFirstAvailableSource()
    {
        foreach (var src in sources)
        {
            if (!src.isPlaying)
            {
                return src;
            }
        }
        return CloneSource();
    }

    AudioSource CloneSource()
    {
        var go = Instantiate<GameObject>(sources[0].gameObject, transform);
        go.name = $"{gameObject.name}Audio{sources.Count}";
        var src = go.GetComponent<AudioSource>();
        sources.Add(src);
        return src;
    }
}
