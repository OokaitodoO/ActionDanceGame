using UnityEngine;

public class TapNoteController : BaseNote
{
    public override void Initialize()
    {
        base.Initialize();
        //Init specific tap note action
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(Success);
    }

    public override void Success()
    {
        base.Success();

        //Calculate accuracy


        Destroy(gameObject);
    }
}
