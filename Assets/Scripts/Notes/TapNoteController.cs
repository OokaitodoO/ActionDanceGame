using UnityEngine;

public class TapNoteController : BaseNote
{    
    public override void OnTap()
    {
        //Check current time in Timeline director for accuracy
        Debug.Log($"Click button tap note");
    }
}
