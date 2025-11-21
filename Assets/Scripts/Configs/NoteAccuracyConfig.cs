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

    public double PerfectOffset => hitOffset;
    public double GoodOffset => hitOffset * 1.5f;
    public double BadOffset => hitOffset * 2f;

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
        if (currentTime <= hitTime + PerfectOffset 
            && currentTime >= hitTime - PerfectOffset)
        {            
            return AccuracyType.Perfect;
        }
        else if (currentTime <= (hitTime + GoodOffset) 
                && currentTime >= (hitTime - GoodOffset))
        {         
            return AccuracyType.Good;
        }
        else if (currentTime <= (hitTime + BadOffset) 
                && currentTime >= (hitTime - BadOffset))
        {         
            return AccuracyType.Bad;
        }
        
        return AccuracyType.Miss;
    }    
}
