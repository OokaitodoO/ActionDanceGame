using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using static NoteDefination;

[System.Serializable]
[CreateAssetMenu(fileName = "NewRhythmClip", menuName = "Timeline/RhythmClip")]
public class RhythmClip : PlayableAsset, ITimelineClipAsset
{
    [HideInInspector]
    public double clipStartTime;
    [HideInInspector]
    public double clipEndTime;

    [SerializeField] private NoteDefination defination;
    [Header("Settings")]
    [SerializeField] private double spawnTime;
    [SerializeField] private Vector3 spawnPosition;

    private RhythmBehaviour template = new();
    public double FixedDuration => defination.duration;
    public bool isLockedDuration => defination.isLocked;
    [HideInInspector]
    public GameObject _spawnedInstance;

    public ClipCaps clipCaps => ClipCaps.None; 

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        template.prefabToSpawn = defination.GetPrefab();
        template.spawnLocation = spawnPosition;

        template.clipStartTime = clipStartTime;
        template.clipEndTime = clipEndTime;

        template.SetListener(OnSpawnInstance); 

        //Get clip start time        
        /*var clip = (ITimelineClipAsset)this as TimelineClip;
        if (clip != null)
        {
            template.clipStartTime = clip.start;
            template.noteTime = (clip.start + clip.end) / 2;
            Debug.Log("Assign clip attributes!");
        }*/


        return ScriptPlayable<RhythmBehaviour>.Create(graph, template);
    }      

    public NoteDefination GetDefination()
    {
        return defination;
    }

    private void OnSpawnInstance(GameObject instance)
    {
        _spawnedInstance = instance;
    }

}
