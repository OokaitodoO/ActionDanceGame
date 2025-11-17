using System.Collections.Generic;
using UnityEngine;

public class ComboConfig
{    
    public float GetMultiplier(int currentCombo)
    {
        if (currentCombo <= 20)
        {
            return 1.0f;
        }
        else if (currentCombo <= 40)
        {
            return 1.5f;
        }
        else if (currentCombo <= 60)
        {
            return 2.5f;
        }
        else
        {
            return 3.5f;
        }
    }
}
