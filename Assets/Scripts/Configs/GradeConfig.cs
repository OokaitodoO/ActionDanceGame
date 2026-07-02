using UnityEngine;

public class GradeConfig
{
    public readonly int gradeSS = 102000;
    public readonly int gradeS = 95000;    
    public readonly int gradeA = 85000;    
    public readonly int gradeB = 70000;    
    public readonly int gradeC = 50000;    

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
        if (score >= gradeSS)
        {
            return GradeType.SS;
        }
        else if (score >= gradeS)
        {
            return GradeType.S;
        }
        else if (score >= gradeA)
        {    
            return GradeType.A;
        }
        else if (score >= gradeB)
        {
            return GradeType.B;
        }
        else if (score >= gradeC)
        {
            return GradeType.C;
        }
        else
        {
            return GradeType.F;
        }
    }
}
