using System;
using UnityEngine;
using UnityEngine.Playables;
using Object = UnityEngine.Object;

public class RhythmBehaviour : PlayableBehaviour
{
    public GameObject prefabToSpawn;
    public Vector3 spawnLocation;
    public Transform canvasParent;
    public double clipStartTime;
    public double clipEndTime;
    public double offsetHitTime;

    protected GameObject spawnedInstance;
    protected BaseNote currentNote;
    protected RhythmManager controller;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (spawnedInstance == null && prefabToSpawn != null)
        {
            //Give this game object to who needed to use
            spawnedInstance = Object.Instantiate(prefabToSpawn, canvasParent);
            var rect = spawnedInstance.GetComponent<RectTransform>();
            if(rect)
                rect.localPosition = spawnLocation;                   
            spawnedInstance.name = $"{prefabToSpawn.name}_Instance";

            //Send base note to controller
            var director = playable.GetGraph().GetResolver() as PlayableDirector;
            controller = director.GetComponent<RhythmManager>();
            currentNote = spawnedInstance.GetComponent<BaseNote>();
            offsetHitTime = (clipEndTime - clipStartTime) / 2;
            currentNote.hitTime = clipStartTime + offsetHitTime;
            
            controller.AddQueue(currentNote);
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        DestroyNoteByBehaviour(spawnedInstance);
    }

    public override void OnGraphStop(Playable playable)
    {
        DestroyNoteByBehaviour(spawnedInstance);
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {        
        if (currentNote)
        {
            var localTime = playable.GetTime();           
            currentNote.UpdateOutline(offsetHitTime, clipStartTime, localTime);
        }
    }

    public void DestroyNoteByBehaviour(GameObject obj)
    {
        if (spawnedInstance != null && spawnedInstance == obj)
        {
            if (!Application.isPlaying)
            {
                Object.DestroyImmediate(spawnedInstance);
                controller.DeQueue();
            }
            else
            {                
                Object.Destroy(spawnedInstance);
                controller.DeQueue();
                currentNote.Missed();
            }

            currentNote = null;
            spawnedInstance = null;
        }
    }
}
