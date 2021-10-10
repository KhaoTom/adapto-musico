public interface IMusicSequence
{
    public void Start(int currentBeat);
    public Note GetNote(int currentBeat, Scales currentScale, int currentKey);
}

[System.Serializable]
public class SimpleSequence : IMusicSequence
{
    public int[] scaleDegrees;
    public int beatInterval = 1;

    int currentInterval = 0;
    int nextBeat = -1;

    public void Start(int currentBeat)
    {
        nextBeat = currentBeat;
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

    
}

public static class MusicUtils
{
    public static int GetScaledNote(int rootNote, int scaleDegree, Scales scale)
    {
        int interval = Intervals.FromEnum(scale)[scaleDegree];
        return rootNote + interval;
    }
}
