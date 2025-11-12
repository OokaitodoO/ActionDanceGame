using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TempoTrack))]
public class TempoTrackEditor : Editor
{
    private TempoTrack track => target as TempoTrack;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(10);

        if (GUILayout.Button("Generate tempo"))
        {
            track.GenerateTempo();
        }
        if (GUILayout.Button("Clear tempo"))
        {
            track.DeleteAllClip();
        }
    }
}
