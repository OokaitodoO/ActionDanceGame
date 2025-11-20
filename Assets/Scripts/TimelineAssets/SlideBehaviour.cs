using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using Object = UnityEngine.Object;

public class SlideBehaviour : RhythmBehaviour
{
    public Vector3 endPosition;
    public double tapDuration;
    public double clipLength;

    private double missTime;
    private SlideNoteController _slideNote;
    private double startMovingTime;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (spawnedInstance == null && prefabToSpawn != null)
        {
            //Give this game object to who needed to use
            spawnedInstance = Object.Instantiate(prefabToSpawn, canvasParent);            

            //Send base note to controller
            var director = playable.GetGraph().GetResolver() as PlayableDirector;
            controller = director.GetComponent<RhythmManager>();
            _slideNote = spawnedInstance.GetComponent<BaseNote>() as SlideNoteController;
            offsetHitTime = tapDuration / 2;            
            _slideNote.hitTime = clipStartTime + offsetHitTime;
            _slideNote.clipLength = clipEndTime - clipStartTime;
            _slideNote.SetListenerMoving(OnTapStartMovingHolder);

            //Set note position
            var rectStart = _slideNote.GetStartTransform();
            if (rectStart)
                rectStart.localPosition = spawnLocation;
            //Set end position
            var rectEnd = _slideNote.GetEndTransform();
            if (rectStart)
                rectEnd.localPosition = endPosition;

            spawnedInstance.name = $"{prefabToSpawn.name}_Instance";

            controller.AddQueue(_slideNote);
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        base.OnBehaviourPause(playable, info);        
    }

    public override void OnGraphStop(Playable playable)
    {
        base.OnGraphStop(playable);        
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        var localTime = playable.GetTime();
        if (_slideNote)
        {
            if (!_slideNote.isMoving)
            {
                Debug.Log("not moving");
                startMovingTime = localTime;
                _slideNote.UpdateOutline(offsetHitTime, clipStartTime, localTime);
                if (localTime >= tapDuration)
                {
                    Debug.Log("Past tap time");
                    //For stand alone
                    if (!Application.isPlaying)
                    {
                        _slideNote.isMoving = true;
                    }
                    else
                    {
                        _slideNote.Missed();
                        //DestroyNoteByBehaviour(spawnedInstance, _slideNote);
                        _slideNote = null;
                    }                    
                }
            }
            else
            {
                //For stand alone
                //Movig this note to end position
                if (!Application.isPlaying)
                {
                    _slideNote.startMovingTime = startMovingTime;
                    _slideNote.GetHolderTransform().gameObject.SetActive(true);
                    _slideNote.MoveToEndPositionPreview(localTime);
                }
                else
                {
                    _slideNote.MoveToEndPosition(localTime);
                }
            }                       
        }
    }

    private void OnTapStartMovingHolder(SlideNoteController slide)
    {
        slide.startMovingTime = startMovingTime;
    }
}
