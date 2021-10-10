public struct Note
{
    public int noteNumber;
    public float volume;

    public Note(int noteNumber, float volume)
    {
        this.noteNumber = noteNumber;
        this.volume = volume;
    }

    private static Note _none = new Note(-1, -1f);
    public static Note None { get => _none; }

    public static bool operator ==(Note c1, Note c2)
    {
        return c1.Equals(c2);
    }

    public static bool operator !=(Note c1, Note c2)
    {
        return !c1.Equals(c2);
    }

    public override bool Equals(object obj)
    {
        return obj is Note note &&
               noteNumber == note.noteNumber &&
               volume == note.volume;
    }

    public override int GetHashCode()
    {
        int hashCode = -627556953;
        hashCode = hashCode * -1521134295 + noteNumber.GetHashCode();
        hashCode = hashCode * -1521134295 + volume.GetHashCode();
        return hashCode;
    }
}
