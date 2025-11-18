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

    public override void DrawBackground(TimelineClip clip, ClipBackgroundRegion region)
    {
        if (clip.asset is RhythmClip rhythmClipAsset)
        {
            
            var iconSize = new Vector2(32, 32);

            var startRegion = new Rect(
                region.position.position.x,
                ((region.position.position.y + region.position.height) / 2) - iconSize.y / 2,
                iconSize.x,
                iconSize.y);

            var endRegion = new Rect(
                region.position.position.x + region.position.width - iconSize.x,
                ((region.position.position.y + region.position.height) / 2) - iconSize.y / 2,
                iconSize.x,
                iconSize.y);

            var centerRegion = new Rect(
                ((region.position.position.x + region.position.width) / 2) - iconSize.x / 2,
                ((region.position.position.y + region.position.height) / 2) - iconSize.y / 2,
                iconSize.x,
                iconSize.y);

            var backgroundRegion = new Rect(
                region.position.position.x,
                region.position.position.y + iconSize.y / 4,
                region.position.width,
                iconSize.y / 2);

            var defination = rhythmClipAsset.GetDefination();
            if (defination)
            {
                EditorGUI.DrawRect(backgroundRegion, defination.bgColor);

                Color previousGuiColor = GUI.color;
                GUI.color = Color.clear;

                if (defination.leftIcon)
                {
                    var texture = defination.leftIcon;
                    EditorGUI.DrawTextureTransparent(startRegion, texture);                    
                }
                if (defination.centerIcon)
                {
                    var texture = defination.centerIcon;
                    EditorGUI.DrawTextureTransparent(centerRegion, texture);
                }
                if (defination.rightIcon)
                {
                    var texture = defination.rightIcon;
                    EditorGUI.DrawTextureTransparent(endRegion, texture);
                }

                GUI.color = previousGuiColor;
            }            
        }
    }
}
