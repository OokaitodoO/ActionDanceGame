using Rhythm;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackClipType(typeof(RhythmClip))]
public class RhythmTrack : TrackAsset
{
    public int ID;
    public float BPM;
}
