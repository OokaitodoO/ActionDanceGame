using Rhythm;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackClipType(typeof(RhythmClip))]
public class TempoTrack : TrackAsset
{
    public float BPM;
    
    public void GenerateTempoMarker()
    {
        if (BPM > 0)
        {
            Debug.Log("Create tempo marker");
            //Loop by BPM offset to create marker            
        }
    }
}
