using Rhythm;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackClipType(typeof(RhythmClip))]
[TrackClipType(typeof(TempoClip))]
public class TempoTrack : TrackAsset
{
    public float BPM;
    
    public void GenerateTempoMarker()
    {
        if (BPM > 0)
        {
            Debug.Log("Create tempo marker");
            var clip = CreateClip<TempoClip>();            
            //Loop by BPM offset to create tempo           
        }
    }
}
