using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeNoteController : BaseNote
{
    [SerializeField] private Image directionSprite;
    [Space]
    [SerializeField] private Sprite arrow;

    [HideInInspector]
    public DirecitonConfig inputDirection;

    public override void OnPointerDown(PointerEventData eventData)
    {
        //Get start pointer position
    }

    public override void OnDrag(PointerEventData eventData)
    {
        //Get current pointer position
        //Calculate direction
    }
}
