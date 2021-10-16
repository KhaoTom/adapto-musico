using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SequenceTests
{
    [SetUp]
    public void Setup()
    {

    }

    [TearDown]
    public void Teardown()
    {

    }

    private SimpleSequence CreateSimpleSequenceFromScaleDegreeArray(int[] scaleDegrees)
    {
        SimpleSequence seq = new SimpleSequence();
        seq.scaleDegrees = scaleDegrees;
        return seq;
    }

    private SequencePlayer CreateSequencePlayerFromBeatIntervalArray(int[] beatIntervals)
    {
        BeatStep[] beatSteps = new BeatStep[beatIntervals.Length];
        for (int i = 0; i < beatSteps.Length; i++)
        {
            beatSteps[i] = new BeatStep() { interval = beatIntervals[i] };
        }

        SequencePlayer seqPlayer = new SequencePlayer();
        seqPlayer.beatSteps = beatSteps;
        return seqPlayer;
    }

    private Note[] CreateNotesWithNoteNumberArray(int[] noteNumbers)
    {
        Note[] notes = new Note[noteNumbers.Length];
        for (int i = 0; i < notes.Length; i++)
        {
            if (noteNumbers[i] == -1)
            {
                notes[i] = Note.None;
            }
            else
            {
                notes[i] = new Note(noteNumbers[i], 1.0f);
            }
        }
        return notes;
    }

    [Test]
    public void SequencePlayerGetNoteNumberTestPasses()
    {
        SimpleSequence seq = CreateSimpleSequenceFromScaleDegreeArray(new int[] { 0, 1, 2, 3 });
        SequencePlayer seqPlayer = CreateSequencePlayerFromBeatIntervalArray(new int[] { 1, 2, 3});

        seqPlayer.sequence = seq;
        seqPlayer.nextBeat = 0;

        int rootNote = 69;
        Scales scale = Scales.Ionian;

        List<Note> output = new List<Note>();
        for (int beat = 0; beat < 10; beat++)
        {
            var note = seqPlayer.GetNote(beat, rootNote, scale);
            output.Add(note);
        }

        Note[] expected = CreateNotesWithNoteNumberArray(new int[] { 69, 71, -1, 73, -1, -1, 74, 69, -1, 71 });
        Assert.That(output.ToArray(), Is.EquivalentTo(expected));
    }

}
