using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

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
                "Confirm Generate Tempo",
                "This will generate tempo clip with BPM",
                "Confirm", "Cancel"))
            {
                track.GenerateTempo();
            }
        }

        GUILayout.Space(10);

        if (GUILayout.Button("Manually Delete All Tempo Clip"))
        {
            if (EditorUtility.DisplayDialog(
                "Confirm delete all tempo",
                "This will delete all tempo on track",
                "Confirm", "Cancel"))
            {
                track.DeleteAllClip();
            }
        }
    }    
}
