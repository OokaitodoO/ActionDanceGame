using UnityEngine;
using UnityEngine.EventSystems;

public class TapNoteController : BaseNote
{
    //public override void Initialize()
    //{
    //    base.Initialize();
    //    //Init specific tap note action
    //    //button.onClick.RemoveAllListeners();
    //    //button.onClick.AddListener(Success);        
    //}

    public override void Success()
    {
        base.Success();

        Destroy(gameObject);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Success();
    }
}
