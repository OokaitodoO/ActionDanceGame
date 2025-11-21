using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEditor.Timeline;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class ManagerEditor : Editor
{
    private GameManager gameManager;

    private void OnEnable()
    {
        gameManager = (GameManager)target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Initial track"))
        {
            gameManager.InitTrack();
        }
        EditorGUILayout.Space(10);
        base.OnInspectorGUI();

        
    }
}
