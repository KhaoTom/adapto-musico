public interface IMusicSequence
{
    public void Start(int currentBeat);
    public Note GetNote(int currentBeat);
}

[System.Serializable]
public class SimpleSequence : IMusicSequence
{
    public int[] notes;
    public int beatInterval = 1;

    int currentNote = 0;
    int nextBeat = -1;

    public void Start(int currentBeat)
    {
        nextBeat = currentBeat;
    }

    public Note GetNote(int currentBeat)
    {
        if (currentBeat >= nextBeat)
        {
            var result = new Note(notes[currentNote], 1.0f);
            currentNote = currentNote.Plus1Wrap0(notes.Length);
            nextBeat += beatInterval;
            return result;
        }
        return Note.None;
    }
}
