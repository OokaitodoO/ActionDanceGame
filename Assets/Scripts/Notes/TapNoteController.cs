
using UnityEngine;
using UnityEngine.EventSystems;

public class TapNoteController : BaseNote
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (interacable)
        {
            accuracy = _accuracyConfig.CalculateAccuracy(director.time, hitTime);
            base.Success();
        }
        else
        {
            base.Check();

            accuracy = _accuracyConfig.CalculateAccuracy(director.time, hitTime);
            base.Success();
        }
    }
}
