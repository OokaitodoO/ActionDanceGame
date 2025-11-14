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
    private RhythmController _controller;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (_spawnedInstance == null && prefabToSpawn != null)
        {
            //Give this game object to who needed to use
            _spawnedInstance = Object.Instantiate(prefabToSpawn, canvasParent);
            _spawnedInstance.transform.position = spawnLocation;
            _spawnedInstance.name = $"{prefabToSpawn.name}_Instance";

            //Send base note to controller
            var director = playable.GetGraph().GetResolver() as PlayableDirector;
            _controller = director.GetComponent<RhythmController>();
            _currentNote = _spawnedInstance.GetComponent<BaseNote>();
            _controller.AddQueue(_currentNote);
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        DestroyNoteByBehaviour(_spawnedInstance);
    }

    public override void OnGraphStop(Playable playable)
    {
        DestroyNoteByBehaviour(_spawnedInstance);
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {        
        if (_currentNote)
        {
            var localTime = playable.GetTime();
            offsetHitTime = (clipEndTime - clipStartTime)/2;
            _currentNote.UpdateOutline(offsetHitTime, clipStartTime, localTime);
        }
    }

    public void DestroyNoteByBehaviour(GameObject obj)
    {
        if (_spawnedInstance != null && _spawnedInstance == obj)
        {
            if (!Application.isPlaying)
            {
                Object.DestroyImmediate(_spawnedInstance);
                _controller.DeQueue();
            }
            else
            {                
                Object.Destroy(_spawnedInstance);
                _controller.DeQueue();
            }

            _currentNote = null;
            _spawnedInstance = null;
        }
    }
}
