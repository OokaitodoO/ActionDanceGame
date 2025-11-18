using UnityEngine;

public class GradeConfig
{
    public enum GradeType
    {
        SS,
        S,
        A,
        B,
        C,
        F,
    }
    public GradeType CalculateGrade(int score)
    {
        if (score >= 102000)
        {
            return GradeType.SS;
        }
        else if (score >= 95000)
        {
            return GradeType.S;
        }
        else if (score >= 85000)
        {    
            return GradeType.A;
        }
        else if (score >= 70000)
        {
            return GradeType.B;
        }
        else if (score >= 50000)
        {
            return GradeType.C;
        }
        else
        {
            return GradeType.F;
        }
    }
}
