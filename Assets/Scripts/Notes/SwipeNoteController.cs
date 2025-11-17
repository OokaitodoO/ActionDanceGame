using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeNoteController : BaseNote
{
    [Space]
    [SerializeField] private Image directionSprite;
    //[SerializeField] private Sprite arrow;

    private float[] rotation =
    {
        0, //Down
        90, //Right
        180, // up
        270 //Left
    };

    [HideInInspector]
    public DirecitonConfig inputDirection;

    public override void Initialize()
    {
        RandomDirection();
        base.Initialize();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        //Get start pointer position
    }

    public override void OnDrag(PointerEventData eventData)
    {
        //Get current pointer position
        //Calculate direction
    }

    private void RandomDirection()
    {

    }
}
