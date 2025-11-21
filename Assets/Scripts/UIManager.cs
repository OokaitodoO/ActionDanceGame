using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("In game")]
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text combo;
    [SerializeField] private TMP_Text accuracy;
    [Header("Sum panel")]
    [SerializeField] private TMP_Text perfectCount;
    [SerializeField] private TMP_Text goodCount;
    [SerializeField] private TMP_Text badCount;
    [SerializeField] private TMP_Text missCount;
    [SerializeField] private TMP_Text totalScore;
    [SerializeField] private TMP_Text highestCombo;
    [SerializeField] private TMP_Text grade;

    public void UpdateScore(int currentScore)
    {
        score.SetText($"Score : {currentScore}");
    }

    public void UpdateCombo(int currentCombo)
    {
        combo.SetText($"X{currentCombo} Combo");
    }

    public void UpdateAccuracy(AccuracyType acc)
    {
        accuracy.SetText(acc.ToString());
    }

    public void UpdateStatisticAcc(int perfect, int good, int bad, int miss, int h_combo, int score)
    {
        perfectCount.SetText($"Perfect : {perfect}");
        goodCount.SetText($"Good : {good}");
        badCount.SetText($"Bad : {bad}");
        missCount.SetText($"Miss : {miss}");

        highestCombo.SetText($"Combo : {h_combo}");
        totalScore.SetText($"Score : {score}");
    }

    public void UpdateGrade(GradeConfig.GradeType gradeType)
    {
        grade.SetText($"{gradeType.ToString()}");
    }    
}
