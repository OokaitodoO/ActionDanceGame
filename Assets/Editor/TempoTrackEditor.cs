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
            if (EditorUtility.DisplayDialog("Confirm generate",
                "This will generate beat from BPM.",
                "Confirm", "Cancel"))
            {
                track.GenerateTempo();
            }
        }
        if (GUILayout.Button("Clear tempo"))
        {
            if (EditorUtility.DisplayDialog("Confirm Delete clips",
                "This will Delete all clip in this track.",
                "Confirm", "Cancel"))
            {
                track.DeleteAllClip();
            }
        }
    }
}
