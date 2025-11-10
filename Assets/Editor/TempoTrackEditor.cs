using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;

[CustomEditor(typeof(TempoTrack))]
public class TempoTrackEditor : Editor
{
    private TempoTrack track;

    private void OnEnable()
    {
        track = target as TempoTrack;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        GUILayout.Space(10);

        if (GUILayout.Button("Manually Generate Tempo Clips"))
        {
            if (EditorUtility.DisplayDialog(
                "Confirm Generation",
                "This will clear all existing tempo clips on this track. Are you sure?",
                "Generate", "Cancel"))
            {
                track.GenerateTempoMarker();
            }
        }
    }
}
