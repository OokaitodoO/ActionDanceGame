using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class RhythmController : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;

    private Queue<BaseNote> queueNotes = new();

    private void Start()
    {
        GetTrack();
    }

    public void AddQueue(BaseNote note)
    {
        Debug.Log("Add queue");
        queueNotes.Enqueue(note);
    }

    public void DeQueue()
    {
        queueNotes.Dequeue();
    }

    public void GetTrack()
    {
        var asset = director.playableAsset;
        if (asset is TimelineAsset timeLineAsset)
        {
            foreach (var track in timeLineAsset.GetRootTracks())
            {
                Debug.Log($"Track: {track.name}");
            }
        }
    }
}
