using TMPro;
using UnityEngine;

public class RhythmUI : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text combo;

    public void UpdateScore(int currentScore)
    {
        score.SetText($"Score : {currentScore}");
    }

    public void UpdateCombo(int currentCombo)
    {
        combo.SetText($"X{currentCombo} Combo");
    }
}
