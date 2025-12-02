using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("In game")]
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text combo;
    [SerializeField] private TMP_Text accuracy;
    [SerializeField] private TMP_Text currentGrade;
    [SerializeField] private Image gradeProgressBar;
    [Header("Sum panel")]
    [SerializeField] private TMP_Text perfectCount;
    [SerializeField] private TMP_Text goodCount;
    [SerializeField] private TMP_Text badCount;
    [SerializeField] private TMP_Text missCount;
    [SerializeField] private TMP_Text totalScore;
    [SerializeField] private TMP_Text highestCombo;
    [SerializeField] private TMP_Text sumGrade;
    [Header("Song")]
    [SerializeField] private Transform songParent;
    [Header("Animation")]
    [SerializeField] private AnimationClip flash;

    private void Start()
    {
        WrapGamePlayUIInitialize();
    }

    private void WrapGamePlayUIInitialize()
    {
        score.raycastTarget = false;
        combo.raycastTarget = false;
        accuracy.raycastTarget = false;
        currentGrade.raycastTarget = false;
        gradeProgressBar.raycastTarget = false;
    }

    public void UpdateScore(int currentScore)
    {
        score.SetText(currentScore.ToString().PadLeft(6, '0'));
        //var anim = score.GetComponent<Animation>();
        //if (anim)
        //    anim.Play(flash.name);        
    }

    public void UpdateCombo(int currentCombo)
    {
        combo.SetText($"{currentCombo}x");
        var anim = combo.GetComponent<Animation>();
        if(anim)
            anim.Play(flash.name);        
    }

    public void UpdateAccuracy(AccuracyType acc)
    {
        accuracy.SetText(acc.ToString());
    }

    public void UpdateStatistic(int perfect, int good, int bad, int miss, int h_combo, int score)
    {
        perfectCount.SetText($"Perfect : {perfect}");
        goodCount.SetText($"Good : {good}");
        badCount.SetText($"Bad : {bad}");
        missCount.SetText($"Miss : {miss}");

        highestCombo.SetText($"Combo : {h_combo}");
        totalScore.SetText($"Score : {score}");        
    }

    public void UpdateGrade(GradeConfig config, int currentScore)        
    {
        var gradeType = config.CalculateGrade(currentScore);
        sumGrade.SetText($"{gradeType.ToString()}");
        currentGrade.SetText($"{gradeType.ToString()}");
        if (gradeProgressBar.gameObject.activeSelf)
        {            
            float amount = currentScore / (float)config.gradeSS;
            gradeProgressBar.fillAmount = Mathf.Clamp01(amount);
        }
    }

    public void UpdateGrade(GradeConfig.GradeType gradeType)
    {
        sumGrade.SetText($"{gradeType.ToString()}");        
    }
}
