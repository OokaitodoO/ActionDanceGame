using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Timeline;

[CustomTimelineEditor(typeof(RhythmClip))]
public class ClipDrawer : ClipEditor
{
    private const float ICON_SIZE = 16f;

    public override void DrawBackground(TimelineClip clip, ClipBackgroundRegion region)
    {
        base.DrawBackground(clip, region);
        
    }
}
