public interface IMusicSequence
{
    public void Start(int currentBeat);
    public Note GetNote(int currentBeat, Scales currentScale, int currentKey);
    public IMusicSequence Clone();
}

[System.Serializable]
public class SimpleSequence : IMusicSequence
{
    public int[] scaleDegrees;
    public int beatInterval = 1;
    public int startDelay = 0;

    int currentInterval = 0;
    int nextBeat = -1;

    public void Start(int currentBeat)
    {
        nextBeat = currentBeat + startDelay;
    }

    public Note GetNote(int currentBeat, Scales currentScale, int currentKey)
    {
        if (currentBeat >= nextBeat)
        {
            var scaleDegree = scaleDegrees[currentInterval];
            currentInterval = currentInterval.Plus1Wrap0(scaleDegrees.Length);

            var noteNumber = MusicUtils.GetScaledNote(currentKey, scaleDegree, currentScale);
            var result = new Note(noteNumber, 1.0f);
            nextBeat += beatInterval;
            return result;
        }
        return Note.None;
    }

    public IMusicSequence Clone()
    {
        var newSeq = new SimpleSequence()
        {
            scaleDegrees = scaleDegrees,
            beatInterval = beatInterval,
            startDelay = startDelay
        };
        return newSeq;
    }
}

public abstract class SequenceScriptableObject : UnityEngine.ScriptableObject
{
    public abstract IMusicSequence GetSequence();
}
