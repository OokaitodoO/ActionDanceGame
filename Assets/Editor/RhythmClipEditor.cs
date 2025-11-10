using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Timeline;

[CustomTimelineEditor(typeof(RhythmClip))]
public class RhythmClipEditor : ClipEditor
{
    public override void OnClipChanged(TimelineClip clip)
    {        
        base.OnClipChanged(clip);

        if (clip.asset is RhythmClip rhythmClipAsset)
        {
            bool isLocked = rhythmClipAsset.isLockedDuration;
            double requiredDuration = rhythmClipAsset.FixedDuration;

            if (isLocked)
            {
                if (clip.duration != requiredDuration)
                {
                    if (TimelineEditor.inspectedDirector != null)
                    {                        
                        clip.duration = requiredDuration;
                        TimelineEditor.Refresh(RefreshReason.ContentsModified);
                    }
                }
            }          
        }
    }
}
