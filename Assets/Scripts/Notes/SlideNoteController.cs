using UnityEngine;
using UnityEngine.EventSystems;

public class SlideNoteController : BaseNote
{

    private bool isMoving;
    
    public override void OnPointerDown(PointerEventData eventData)
    {
        //Get accuracy but not yet success
        accuracy = _accuracyConfig.CalculateAccuracy(director.time, hitTime);
        //Start moving to end point
        StartMoving();
    }

    public override void OnDrag(PointerEventData eventData)
    {
        //Tracking
        //Check if its arrived end point
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //If release while note moving will miss this note
        if (isMoving)
        {
            Destroy(gameObject);
        }
    }

    private void StartMoving()
    {
        isMoving = true;
    }
}
