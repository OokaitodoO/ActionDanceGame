using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class RhythmController : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private Transform canvasParent;

    private Queue<BaseNote> queueNotes = new();

    private void Start()
    {
        InitTrack();
    }

    public void AddQueue(BaseNote note)
    {
        Debug.Log("Add queue");
        queueNotes.Enqueue(note);
    }

    public void DeQueue(BaseNote note)
    {
        if (note == queueNotes.Peek())
        {
            queueNotes.Dequeue();
        }
    }

    public void InitTrack()
    {
        var asset = director.playableAsset;
        if (asset is TimelineAsset timeLineAsset)
        {
            foreach (var track in timeLineAsset.GetRootTracks())
            {
                if (track is RhythmTrack)
                {
                    Debug.Log($"Track: {track.name}");
                    var rhythm = track as RhythmTrack;
                    rhythm.canvasParent = canvasParent;
                }                
            }
        }
    }
}
