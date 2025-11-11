using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Timeline;

[CustomEditor(typeof(RhythmClip))]
public class RhythmClipAssetEditor : Editor
{
    private SerializedProperty spawnPositionProperty;
    private RhythmClip targetAsset;

    private void OnEnable()
    {
        targetAsset = (RhythmClip)target;        
        spawnPositionProperty = serializedObject.FindProperty("spawnPosition");              
    }
    
    private void OnSceneGUI()
    {        
        if (targetAsset == null || spawnPositionProperty == null)
            return;
        
        Vector3 currentSpawnPosition = spawnPositionProperty.vector3Value;        
        
        Handles.color = Color.cyan;

        Vector3 newSpawnPosition = Handles.PositionHandle(currentSpawnPosition, Quaternion.identity);

        if (newSpawnPosition != currentSpawnPosition)
        {

            Undo.RecordObject(targetAsset, "Move Spawn Position");

            spawnPositionProperty.vector3Value = newSpawnPosition;
            serializedObject.ApplyModifiedProperties();


        }

        Handles.DrawSolidDisc(newSpawnPosition, Vector3.forward, 0.2f);
        Handles.Label(newSpawnPosition + Vector3.up * 0.5f, "Tap Spawn");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        serializedObject.ApplyModifiedProperties();
    }
}
