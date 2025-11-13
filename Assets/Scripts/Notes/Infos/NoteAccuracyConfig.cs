using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public class NoteAccuracyConfig
{
    private readonly Dictionary<string, int> _accuracyInfos = new() 
    {
        {"perfect", 600},
        {"good", 300},
        {"bad", 120},
        {"miss", 0}
    };

    public int GetScoreByAccuracy(string accuracy) => _accuracyInfos[accuracy];    
}
