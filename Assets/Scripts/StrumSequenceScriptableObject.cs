using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StrumSequence", menuName = "Sequences/StrumSequence", order = 2)]
public class StrumSequenceScriptableObject : SequenceScriptableObject
{
    public StrumSequence sequence;

    public override IMusicSequence GetSequence()
    {
        return sequence.Clone();
    }
}
