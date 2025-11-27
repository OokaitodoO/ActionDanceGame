using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MultiTapNoteController : BaseNote
{
    public int tapAmount = 5;

    [SerializeField] private TMP_Text number;
    [SerializeField] private TMP_Text text;

    public override void Initialize()
    {
        base.Initialize();
        UpdateNumberAmount();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        tapAmount -= 1;
        if (tapAmount <= 0)
        {
            //get point
            accuracy = AccuracyType.Perfect;
            base.Success();
        }
        UpdateNumberAmount();
    }

    private void UpdateNumberAmount()
    {
        number.SetText(tapAmount.ToString());
    }
}
