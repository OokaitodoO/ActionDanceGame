using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public enum AccuracyType
{
    Perfect,
    Good,
    Bad,
    Miss,
}

public class NoteAccuracyConfig
{
    public int GetScoreByAccuracyType(AccuracyType accuracy)
    {
        switch (accuracy)
        {
            case AccuracyType.Perfect:
                return 600;
            case AccuracyType.Good:
                return 300;
            case AccuracyType.Bad:
                return 120;
            default:
                return 0;
        }
    }
}
