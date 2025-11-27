using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.Rendering;
using static NoteDefinition;

//[CustomEditor(typeof(RhythmClip))]
public class NoteClipEditor : Editor
{
    private SerializedObject noteDefinitionSO;
    public override void OnInspectorGUI()
    {
        DrawPropertiesExcluding(serializedObject, new string[] { "definition", "m_Script" });

        EditorGUILayout.Space(10);
        
        SerializedProperty definitionProp = serializedObject.FindProperty("definition");        
        EditorGUILayout.PropertyField(definitionProp, new GUIContent("Note Definition Asset"));
        
        if (definitionProp.objectReferenceValue != null)
        {
            NoteDefinition noteDef = definitionProp.objectReferenceValue as NoteDefinition;
            
            if (noteDefinitionSO == null || noteDefinitionSO.targetObject != noteDef)
            {                
                noteDefinitionSO = new SerializedObject(noteDef);
            }
            
            noteDefinitionSO.Update();

            EditorGUILayout.Space(10);
            SerializedProperty noteTypeProperty = noteDefinitionSO.FindProperty("noteType");

            if (noteTypeProperty != null)
            {
                //EditorGUILayout.PropertyField(noteTypeProperty);
             
                NoteType type = (NoteType)noteTypeProperty.enumValueIndex;

                switch (type)
                {
                    case NoteType.Slide:
                        break;
                    case NoteType.MultiTap:
                        ConfigMultiTap();
                        break;
                }
            }
            else
            {
                EditorGUILayout.HelpBox("Error: Could not find 'noteType' property on the NoteDefinition asset.", MessageType.Error);
            }            
        }        
        serializedObject.ApplyModifiedProperties();
    }

    private void ConfigMultiTap()
    {
        SerializedProperty notePrefab = noteDefinitionSO.FindProperty("prefab");
        if (notePrefab != null)
        {
            Debug.Log($"Found note prefab");
            GameObject go = notePrefab.objectReferenceValue as GameObject;
            var note = go.GetComponent<MultiTapNoteController>();
            if (note)
            {
                Debug.Log($"Found multi tap component");
                SerializedObject noteConverted = new(note);
                SerializedProperty amount = noteConverted.FindProperty("tapAmount");
                EditorGUILayout.PropertyField(amount);
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
