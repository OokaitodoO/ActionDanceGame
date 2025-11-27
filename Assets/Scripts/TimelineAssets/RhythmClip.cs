using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using static NoteDefinition;

[System.Serializable]
[CreateAssetMenu(fileName = "NewRhythmClip", menuName = "Timeline/RhythmClip")]
public class RhythmClip : PlayableAsset, ITimelineClipAsset
{
    [HideInInspector]
    public double clipStartTime;
    [HideInInspector]
    public double clipEndTime;

    [SerializeField] protected NoteDefinition definition;
    [Header("Settings")]
    //[SerializeField] private double spawnTime;
    [SerializeField] protected Vector3 spawnPosition;

    protected RhythmBehaviour template = new();
    public double FixedDuration => definition.duration;
    public bool isLockedDuration => definition.isLocked;

    [HideInInspector]
    public Transform canvasParent;
    [HideInInspector]
    public GameObject _spawnedInstance;

    public ClipCaps clipCaps => ClipCaps.None; 

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        template.prefabToSpawn = definition.GetPrefab();
        template.spawnLocation = spawnPosition;
        template.canvasParent = canvasParent;

        template.clipStartTime = clipStartTime;
        template.clipEndTime = clipEndTime;        

        return ScriptPlayable<RhythmBehaviour>.Create(graph, template);
    }      

    public NoteDefinition GetDefination()
    {
        return definition;
    }

    private void OnSpawnInstance(GameObject instance)
    {
        _spawnedInstance = instance;
    }

}
