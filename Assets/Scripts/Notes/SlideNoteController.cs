using UnityEngine;
using UnityEngine.EventSystems;

public class SlideNoteController : BaseNote
{
    public bool isMoving { private set; get; }
    public double clipLength;

    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private Transform holderPosition;
    
    
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

    public void MoveToEndPosition(double localTime)
    {
        //float T_norm = Mathf.Clamp01((float)localTime / (float)offsetHitTime);
        float T_norm = Mathf.Clamp01((float)localTime / (float)clipLength);
        holderPosition.position = Vector3.Lerp(startPosition.position, endPosition.position, 0f);
    }

    private void Arrived()
    {
        base.Success();
    }
}
