using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackClipType(typeof(RhythmClip))]
public class RhythmTrack : TrackAsset
{
    //public int ID;
    //public float BPM;
    public Transform canvasParent;

    protected override Playable CreatePlayable(PlayableGraph graph, GameObject gameObject, TimelineClip clip)
    {        
        foreach (TrackAsset track in timelineAsset.GetOutputTracks())
        {
            foreach (var m_clip in track.GetClips())
            {
                if (m_clip.asset is RhythmClip)
                {
                    var rhythm = m_clip.asset as RhythmClip;
                    rhythm.clipStartTime = m_clip.start;
                    rhythm.clipEndTime = m_clip.end;
                    rhythm.canvasParent = canvasParent;
                }
            }
        }

        return base.CreatePlayable(graph, gameObject, clip);
    }


}
