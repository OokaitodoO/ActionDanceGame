using UnityEngine;
using UnityEngine.Playables;

public class SlideBehaviour : RhythmBehaviour
{
    public double tapDuration;
    public double clipLength;

    private double missTime;
    private SlideNoteController _currentNote;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (spawnedInstance == null && prefabToSpawn != null)
        {
            //Give this game object to who needed to use
            spawnedInstance = Object.Instantiate(prefabToSpawn, canvasParent);
            //Set note position
            var rect = spawnedInstance.GetComponent<RectTransform>();
            if (rect)
                rect.localPosition = spawnLocation;
            //Set end position

            spawnedInstance.name = $"{prefabToSpawn.name}_Instance";

            //Send base note to controller
            var director = playable.GetGraph().GetResolver() as PlayableDirector;
            controller = director.GetComponent<RhythmManager>();
            _currentNote = spawnedInstance.GetComponent<BaseNote>() as SlideNoteController;
            offsetHitTime = tapDuration / 2;            
            _currentNote.hitTime = clipStartTime + offsetHitTime;
            _currentNote.clipLength = clipLength;

            controller.AddQueue(_currentNote);
        }
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (_currentNote)
        {
            if (!_currentNote.isMoving)
            {
                var localTime = playable.GetTime();
                _currentNote.UpdateOutline(offsetHitTime, clipStartTime, localTime);
                if (localTime >= tapDuration)
                {
                    DestroyNoteByBehaviour(spawnedInstance);
                }
            }            
            //Movig this note to end position
            _currentNote.MoveToEndPosition();
        }
    }
}
