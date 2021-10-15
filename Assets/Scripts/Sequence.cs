public interface IMusicSequence
{
    public void Start(int currentBeat);
    public Note GetNote(int currentBeat, Scales currentScale, int currentKey);
    public IMusicSequence Clone();
}


public abstract class SequenceScriptableObject : UnityEngine.ScriptableObject
{
    public abstract IMusicSequence GetSequence();
}


[System.Serializable]
public class SimpleSequence : IMusicSequence
{
    public int[] scaleDegrees;
    public int beatInterval = 1;
    public int startDelay = 0;

    protected int currentInterval = 0;
    protected int nextBeat = -1;

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

[System.Serializable]
public class StrumSequence : IMusicSequence
{
    public int[] scaleDegrees;
    public int beatInterval = 1;
    public int startDelay = 0;
    public int strumCount = 3;
    public int strumInterval = 1;
    public float strumDelay = 0.1f;
    public float strumVolumeChange = 0f;
    

    protected int currentInterval = 0;
    protected int nextBeat = -1;

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
            var result = new Note(noteNumber, 1.0f, strumCount, strumInterval, strumDelay, strumVolumeChange);
            nextBeat += beatInterval;
            return result;
        }
        return Note.None;
    }

    public IMusicSequence Clone()
    {
        var newSeq = new StrumSequence()
        {
            scaleDegrees = scaleDegrees,
            beatInterval = beatInterval,
            startDelay = startDelay,
            strumCount = strumCount,
            strumDelay = strumDelay,
            strumInterval = strumInterval,
            strumVolumeChange = strumVolumeChange
        };
        return newSeq;
    }
}
