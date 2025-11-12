using UnityEditor.Timeline;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;
using System.Collections.Generic;

[TrackClipType(typeof(TempoClip))]
public class TempoTrack : TrackAsset
{
    private const float FIX_DURATION = 0.025f;

    public float BPM;
    public float offset;

    TempoClip template = new();

    /// <summary>
    /// Use for call on inspector button by TempTrackEditor
    /// </summary>
    public void GenerateTempo()
    {   
        Debug.Log("Log from generate tempo");

        double beatInterval = 60.0 / BPM;        

        for (int i=0; i < 90; i++)
        {
            double newStartTime = offset + (i * beatInterval);
            var newClip = CreateClip<TempoClip>();
            newClip.displayName = "Tempo";
            newClip.start = newStartTime;
            newClip.duration = FIX_DURATION;
        }        
    }   

    public void DeleteAllClip()
    {
        //Check exist track delete all and generate
        var clips = GetClips();
        if (clips.Count() > 0)
        {
            foreach (var clip in clips)
            {
                DeleteClip(clip);
            }
        }
    }
}
