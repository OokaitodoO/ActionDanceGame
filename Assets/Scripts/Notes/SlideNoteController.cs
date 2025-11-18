using UnityEngine;
using UnityEngine.EventSystems;

public class SlideNoteController : BaseNote
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        //Get accuracy but not yet success
    }

    public override void OnDrag(PointerEventData eventData)
    {
        //Tracking
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //If release while note moving will miss this note
    }
}
