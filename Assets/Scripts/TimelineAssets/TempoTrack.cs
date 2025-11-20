using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;
using System.Collections.Generic;
using System;

[TrackClipType(typeof(TempoClip))]
public class TempoTrack : TrackAsset
{
    private const float FIX_DURATION = 0.025f;
    private const float SONGLENGTH = 90f;

    public float BPM;
    public float offset;

    /// <summary>
    /// Use for call on inspector button by TempTrackEditor
    /// </summary>
    public void GenerateTempo()
    {
        Debug.Log("Log from generate tempo");

        double beatInterval = 60.0 / BPM;

        //Find number of tempo in 90 sec
        var amount = FindNumberOfBeat();

        for (int i = 0; i < amount; i++)
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
        //Check exist track delete all
        var clips = GetClips();
        if (clips.Count() > 0)
        {
            foreach (var clip in clips)
            {
                DeleteClip(clip);
            }
        }
    }

    private int FindNumberOfBeat()
    {
        double beatInterval = 60.0 / BPM;

        double availableTime = SONGLENGTH - offset;

        if (availableTime <= 0)
        {
            Debug.LogWarning("Offset exceeds total duration limit. No beats will be generated.");
            return 0;
        }
        
        double rawBeatAmount = availableTime / beatInterval;
        
        int amount = (int)Math.Floor(rawBeatAmount);

        //Debug.Log($"BPM: {BPM}, Beat Interval: {beatInterval:F3}s, Available Time: {availableTime:F3}s, Beats to generate: {amount}");

        return amount;
    }
}
