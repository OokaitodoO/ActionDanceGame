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
    private const float hitOffset = 0.25f;    

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

    public AccuracyType CalculateAccuracy(double currentTime, double hitTime)
    {
        if (currentTime <= hitTime + hitOffset 
            && currentTime >= hitTime - hitOffset)
        {
            Debug.Log("Perfect");
            return AccuracyType.Perfect;
        }
        else if (currentTime <= (hitTime + hitOffset * 1.5f) 
                && currentTime >= (hitTime - hitOffset * 1.5f))
        {
            Debug.Log("Good");
            return AccuracyType.Good;
        }
        else if (currentTime <= (hitTime + hitOffset * 2f) 
                && currentTime >= (hitTime - hitOffset * 2f))
        {
            Debug.Log("Bad");
            return AccuracyType.Bad;
        }

        Debug.Log("Miss");
        return AccuracyType.Miss;
    }
}
