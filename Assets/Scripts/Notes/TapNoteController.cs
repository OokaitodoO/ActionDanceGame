using UnityEngine;

public class TapNoteController : BaseNote
{    
    public override void Tap()
    {        
        base.Tap();

        //Check current time in Timeline director for accuracy
        Debug.Log($"Click button tap note");        
    }
}
