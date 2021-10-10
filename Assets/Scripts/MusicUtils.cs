using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MusicUtils
{
    public static int GetScaledNote(int rootNote, int scaleDegree, Scales scale)
    {
        int interval = Intervals.FromEnum(scale)[scaleDegree];
        return rootNote + interval;
    }
}
