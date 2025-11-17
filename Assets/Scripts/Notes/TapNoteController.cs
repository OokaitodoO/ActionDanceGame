using UnityEngine;
using UnityEngine.EventSystems;

public class TapNoteController : BaseNote
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.Success();
    }
}
