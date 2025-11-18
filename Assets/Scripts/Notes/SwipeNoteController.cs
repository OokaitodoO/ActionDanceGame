using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeNoteController : BaseNote
{
    private Dictionary<DirectionConfig, float> rotationDefination = new()
    {
        {DirectionConfig.Down, 0},
        {DirectionConfig.Right, 90},
        {DirectionConfig.Up, 180},
        {DirectionConfig.Left, 270},
    };
    private const float MIN_DISTANCE = 50f;

    [Space]
    [SerializeField] private Image directionImage;
    [SerializeField] private DirectionConfig direction;
    [SerializeField] private bool isRandom;

    [HideInInspector]
    public DirectionConfig inputDirection;
    private Vector2 startPos;
    private Vector2 currentPos;

    public override void Initialize()
    {
        if (isRandom)
        {
            RandomDirection();
        }
        SetImageDirectionRotation();
        base.Initialize();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        //Get start pointer position
        if (interacable)
        {
            startPos = eventData.position;
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (interacable)
        {
            //Get current pointer position
            currentPos = eventData.position;
            //Calculate direction
            var delta = currentPos - startPos;
            var magnitude = delta.magnitude;
            var distance = Vector2.Distance(currentPos, startPos);
            if (magnitude >= MIN_DISTANCE)
            {
                //Set input direction
                inputDirection = SwipeDirection(delta);
                //Check input direction = random direction?
                if (inputDirection == direction)
                {
                    accuracy = _accuracyConfig.CalculateAccuracy(director.time, hitTime);
                    base.Success();
                }
                else
                {
                    base.Missed();
                }
            }
        }
    }

    private void RandomDirection()
    {
        direction = (DirectionConfig)Random.Range(0, 4);        
    }

    private void SetImageDirectionRotation()
    {
        directionImage.rectTransform.localRotation = Quaternion.AngleAxis(rotationDefination[direction], Vector3.forward);
    }

    private DirectionConfig SwipeDirection(Vector2 delta)
    {
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            return delta.x > 0 ? DirectionConfig.Right : DirectionConfig.Left;
        }
        else
        {
            return delta.y > 0 ? DirectionConfig.Up : DirectionConfig.Down;
        }
    }
}
