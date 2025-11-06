using UnityEngine;
using UnityEngine.Timeline;


namespace Rhythm
{
    [TrackClipType(typeof(RhythmClip))]
    public class RhythmTrack : TrackAsset
    {
        public int BPM;
    }
}

