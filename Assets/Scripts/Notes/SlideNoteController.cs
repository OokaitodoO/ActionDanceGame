using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlideNoteController : BaseNote
{
    public bool isMoving;
    public double clipLength;
    public double startMovingTime;

    public event Action<SlideNoteController> OnTapStartMoving;

    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform endTransform;
    [SerializeField] private Transform holderTransform;
    [SerializeField] private Transform arrowTransform;
    [SerializeField] private NoteConnectionLine line;

    private GraphicRaycaster _raycaster;
    private bool _isOverTarget;

    public override void Initialize()
    {
        base.Initialize();
        _raycaster = canvas.GetComponent<GraphicRaycaster>();
        line.SetConnectionLine();
        SetArrowRotation();
    }
    
    public void SetListenerMoving(Action<SlideNoteController> action)
    {
        OnTapStartMoving = action;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (interacable)
        {
            //Get accuracy but not yet success
            accuracy = _accuracyConfig.CalculateAccuracy(director.time, hitTime);
            //Start moving to end point
            StartMoving();

        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        Debug.Log($"On drag");
        List<RaycastResult> results = new List<RaycastResult>();

        _raycaster.Raycast(eventData, results);

        bool currentlyOverTarget = false;

        foreach (RaycastResult result in results)
        {            
            if (result.gameObject == holderTransform.gameObject)
            {
                currentlyOverTarget = true;
                break;
            }
        }        

        if (currentlyOverTarget && !_isOverTarget)
        {            
            //Debug.Log("Pointer ENTERED Target Object while dragging!");            
        }
        else if (!currentlyOverTarget && _isOverTarget)
        {
            //Debug.Log("Pointer EXITED Target Object while dragging!");
            isMoving = false;

            base.Missed();
        }
        
        _isOverTarget = currentlyOverTarget;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //If release while note moving will miss this note
        if (isMoving)
        {            
            base.Missed();
        }
    }

    public Transform GetStartTransform()
    {
        return startTransform;
    }

    public Transform GetEndTransform()
    {
        return endTransform;
    }

    public Transform GetHolderTransform()
    {
        return holderTransform.transform;
    }

    private void StartMoving()
    {
        //Start moving
        OnTapStartMoving?.Invoke(this);

        isMoving = true;
        outLine.gameObject.SetActive(false);
        holderTransform.gameObject.SetActive(true);
    }

    public void MoveToEndPosition(double localTime)
    {
        if (isMoving)
        {
            float T_norm = Mathf.Clamp01(((float)localTime - (float)startMovingTime) / ((float)clipLength - (float)startMovingTime));
            holderTransform.position = Vector3.Lerp(startTransform.position, endTransform.position, T_norm);
            if (Vector3.Distance(holderTransform.position, endTransform.position) <= 0.1f)
            {
                Arrived();
            }
        }       
    }

    public void MoveToEndPositionPreview(double localTime)
    {
        if (isMoving)
        {
            Debug.Log($"Moving");
            float T_norm = Mathf.Clamp01(((float)localTime - (float)startMovingTime) / ((float)clipLength - (float)startMovingTime));       
            holderTransform.position = Vector3.Lerp(startTransform.position, endTransform.position, T_norm);
            if (Vector3.Distance(holderTransform.position, endTransform.position) <= 0.1f)
            {
                //Arrived();
            }
        }
    }

    private void Arrived()
    {
        base.Success();
    }

    private void SetArrowRotation()
    {
        //Find drection
        var direction = endTransform.position - startTransform.position;
        //Find angle
        var angle = MathF.Atan2(direction.y, direction.x);
        var angleDegrees = angle * Mathf.Rad2Deg;
        //Set rotation
        arrowTransform.rotation = Quaternion.Euler(0, 0, angleDegrees - 90);
    }
}
