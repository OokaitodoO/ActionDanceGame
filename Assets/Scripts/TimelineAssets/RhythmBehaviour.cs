using System;
using UnityEngine;
using UnityEngine.Playables;
using Object = UnityEngine.Object;

public class RhythmBehaviour : PlayableBehaviour
{
    public GameObject prefabToSpawn;
    public Vector2 spawnLocation;
    public Transform canvasParent;
    public double clipStartTime;
    public double clipEndTime;
    public double offsetHitTime;

    private GameObject _spawnedInstance;
    private BaseNote _currentNote;
    private PlayableDirector _director;    


    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        var graph = playable.GetGraph();
        var director = graph.GetResolver() as PlayableDirector;

        if (_spawnedInstance == null && prefabToSpawn != null)
        {                   
            _spawnedInstance = Object.Instantiate(prefabToSpawn, canvasParent);
            _spawnedInstance.transform.position = spawnLocation;

            var note = _spawnedInstance.GetComponent<BaseNote>();
            note.SetDirector(director);
            note.Initialize();
            _currentNote = note;

            _spawnedInstance.name = $"{prefabToSpawn.name}_Instance";
            //Debug.Log($"<color=cyan>TL Spawn:</color> '{spawnedInstance.name}' created at time {playable.GetTime()}.");
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {        
        if (_spawnedInstance != null)
        {
            if (!Application.isPlaying)
            {                                
                Object.DestroyImmediate(_spawnedInstance);
            }
            else
            {
                _currentNote.DestroyNote();
                Object.Destroy(_spawnedInstance);
            }

            _spawnedInstance = null;
            _currentNote = null;

            //Debug.Log($"<color=yellow>TL Despawn:</color> Instance destroyed at time {playable.GetTime()}.");
        }
    }

    public override void OnGraphStop(Playable playable)
    {        
        if (_spawnedInstance != null)
        {
            if (!Application.isPlaying)
            {                
                Object.DestroyImmediate(_spawnedInstance);
            }
            else
            {
                _currentNote.DestroyNote();
                Object.Destroy(_spawnedInstance);
            }

            _currentNote = null;
            _spawnedInstance = null;
            //Debug.Log("<color=red>TL Cleanup:</color> Instance destroyed during Graph Stop.");
        }
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        var note = _spawnedInstance.GetComponent<BaseNote>();
        if (note)
        {
            var localTime = playable.GetTime();
            offsetHitTime = (clipEndTime - clipStartTime)/2;
            note.UpdateOutline(offsetHitTime, clipStartTime, localTime);
        }
    }
}
